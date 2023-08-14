using Smakownia.Identity.Application.Requests;
using Smakownia.Identity.Application.Responses;

namespace Smakownia.Identity.Application.Services;

public interface IIdentitiesService
{
    Task<TokensResponse> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default);
    Task<TokensResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default);
}
