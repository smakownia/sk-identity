using Smakownia.Identity.Application.Exceptions;
using Smakownia.Identity.Application.Requests;
using Smakownia.Identity.Application.Responses;
using Smakownia.Identity.Domain;
using Smakownia.Identity.Domain.Entities;
using Smakownia.Identity.Domain.Exceptions;
using Smakownia.Identity.Domain.Repositories;

namespace Smakownia.Identity.Application.Services;

public class IdentitiesService : IIdentitiesService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasherService _passwordHasherService;
    private readonly ITokensService _tokensService;
    private readonly IIdentitiesRepository _identitiesRepository;

    public IdentitiesService(IUnitOfWork unitOfWork,
                             IPasswordHasherService passwordHasherService,
                             ITokensService tokensService,
                             IIdentitiesRepository identitiesRepository)
    {
        _unitOfWork = unitOfWork;
        _passwordHasherService = passwordHasherService;
        _tokensService = tokensService;
        _identitiesRepository = identitiesRepository;
    }

    public async Task<TokensResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default)
    {
        var identity = await _identitiesRepository.GetByEmailOrDefaultAsync(request.Email, cancellationToken);

        if (identity is null || !_passwordHasherService.VerifyPassword(request.Password, identity.Password))
        {
            throw new UnauthorizedException();
        }

        var accessToken = _tokensService.CreateAccessToken(cancellationToken);

        return new(accessToken);
    }

    public async Task<TokensResponse> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default)
    {
        var identityWithSameEmail = await _identitiesRepository.GetByEmailOrDefaultAsync(request.Email, cancellationToken);

        if (identityWithSameEmail is not null)
        {
            throw new IdentityWithSameEmailExistsException(request.Email);
        }

        var hashedPassword = _passwordHasherService.HashPassword(request.Password);
        var identity = new IdentityEntity(request.Email, hashedPassword);

        _identitiesRepository.Add(identity);
        await _unitOfWork.CommitAsync(cancellationToken);

        var accessToken = _tokensService.CreateAccessToken(cancellationToken);

        return new(accessToken);
    }
}
