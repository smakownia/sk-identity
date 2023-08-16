namespace Smakownia.Identity.Application.Responses;

public sealed record IdentityResponse(DateTime Expires, string Role);
