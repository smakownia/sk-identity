using Smakownia.Identity.Application.Requests;
using Smakownia.Identity.Application.Responses;

namespace Smakownia.Identity.Application.Services;

public interface IIdentitiesService
{
    Task<AuthResponse> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default);
    Task<AuthResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default);
}
