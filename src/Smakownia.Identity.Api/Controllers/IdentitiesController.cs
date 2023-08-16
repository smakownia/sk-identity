using Microsoft.AspNetCore.Mvc;
using Smakownia.Identity.Application.Models;
using Smakownia.Identity.Application.Requests;
using Smakownia.Identity.Application.Services;

namespace Smakownia.Identity.Api.Controllers;

[ApiController]
[Route("api/v1/identities")]
public class IdentitiesController : ControllerBase
{
    private readonly IIdentitiesService _identitiesService;

    public IdentitiesController(IIdentitiesService identitiesService)
    {
        _identitiesService = identitiesService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthModel>> Login([FromBody] LoginRequest loginRequest,
                                                     CancellationToken cancellationToken)
    {
        var authModel = await _identitiesService.LoginAsync(loginRequest, cancellationToken);

        Response.Cookies.Append("Authorization",
                                authModel.AccessToken,
                                new CookieOptions
                                {
                                    Expires = DateTime.Now.AddDays(7),
                                    HttpOnly = true
                                });

        return Ok(authModel.Response);
    }

    [HttpPost("register")]
    public async Task<ActionResult<AuthModel>> Register([FromBody] RegisterRequest registerRequest,
                                                        CancellationToken cancellationToken)
    {
        var authModel = await _identitiesService.RegisterAsync(registerRequest, cancellationToken);

        Response.Cookies.Append("Authorization",
                                authModel.AccessToken,
                                new CookieOptions
                                {
                                    Expires = DateTime.Now.AddDays(7),
                                    HttpOnly = true
                                });

        return Ok(authModel.Response);
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("Authorization");

        return Ok();
    }
}
