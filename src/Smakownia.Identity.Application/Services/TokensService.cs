using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Smakownia.Identity.Application.Services;

public class TokensService : ITokensService
{
    private readonly string _secretKey;

    public TokensService(IConfiguration configuration)
    {
        _secretKey = configuration["SecretKey"];
    }

    public string CreateAccessToken(IEnumerable<Claim> claims, DateTime expires)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        var signinCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var tokenOptions = new JwtSecurityToken(
                expires: expires,
                signingCredentials: signinCredentials,
                claims: claims);

        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }
}
