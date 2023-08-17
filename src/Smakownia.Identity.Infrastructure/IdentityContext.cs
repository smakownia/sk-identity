using Microsoft.EntityFrameworkCore;
using Smakownia.Identity.Domain.Entities;
using Smakownia.Identity.Infrastructure.EntityConfigurations;

namespace Smakownia.Identity.Infrastructure;

public class IdentityContext : DbContext
{
    public IdentityContext(DbContextOptions options) : base(options) { }

    public DbSet<IdentityEntity> Identities { get; set; }

    public void ApplyMigrations()
    {
        if (Database.GetPendingMigrations().Any())
        {
            Database.Migrate();
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new IdentityEntityConfiguration());
    }
}
