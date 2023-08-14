using Microsoft.AspNetCore.Mvc;
using Smakownia.Identity.Application.Requests;
using Smakownia.Identity.Application.Responses;
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
    public async Task<ActionResult<TokensResponse>> Login([FromBody] LoginRequest loginRequest,
                                                          CancellationToken cancellationToken)
    {
        return Ok(await _identitiesService.LoginAsync(loginRequest, cancellationToken));
    }

    [HttpPost("register")]
    public async Task<ActionResult<TokensResponse>> Register([FromBody] RegisterRequest registerRequest,
                                                             CancellationToken cancellationToken)
    {
        return Ok(await _identitiesService.RegisterAsync(registerRequest, cancellationToken));
    }
}
