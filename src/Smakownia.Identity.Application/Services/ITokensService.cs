using System.Security.Claims;

namespace Smakownia.Identity.Application.Services;

public interface ITokensService
{
    string CreateAccessToken(IEnumerable<Claim> claims, DateTime expires);
}
