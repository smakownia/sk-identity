using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smakownia.Identity.Domain;
using Smakownia.Identity.Domain.Repositories;
using Smakownia.Identity.Infrastructure.Repositories;

namespace Smakownia.Identity.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IdentityContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("Postgres")));

        services.AddTransient<IIdentitiesRepository, IdentitiesRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
