using Microsoft.Extensions.DependencyInjection;
using Smakownia.Identity.Application.Services;

namespace Smakownia.Identity.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IPasswordHasherService, PasswordHasherService>();
        services.AddTransient<ITokensService, TokensService>();
        services.AddTransient<IIdentitiesService, IdentitiesService>();

        return services;
    }
}

