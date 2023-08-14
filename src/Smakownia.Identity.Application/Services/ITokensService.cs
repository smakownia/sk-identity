namespace Smakownia.Identity.Application.Services;

public interface ITokensService
{
    string CreateAccessToken(CancellationToken cancellationToken = default);
}
