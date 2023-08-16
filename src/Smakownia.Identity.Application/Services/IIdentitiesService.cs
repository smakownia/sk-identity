using Smakownia.Identity.Application.Models;
using Smakownia.Identity.Application.Requests;

namespace Smakownia.Identity.Application.Services;

public interface IIdentitiesService
{
    Task<AuthModel> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default);
    Task<AuthModel> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default);
}
