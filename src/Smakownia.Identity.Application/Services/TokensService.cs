using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Smakownia.Identity.Application.Services;

public class TokensService : ITokensService
{
    private readonly string _secretKey;

    public TokensService(IConfiguration configuration)
    {
        _secretKey = configuration["SecretKey"];
    }

    public string CreateAccessToken(CancellationToken cancellationToken = default)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        var signinCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var tokenOptions = new JwtSecurityToken(
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: signinCredentials);

        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }
}
