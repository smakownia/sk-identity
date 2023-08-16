using Smakownia.Identity.Application.Responses;

namespace Smakownia.Identity.Application.Models;

public sealed record AuthModel(string AccessToken, IdentityResponse Response);
