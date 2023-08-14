using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smakownia.Identity.Domain.Entities;

namespace Smakownia.Identity.Infrastructure.EntityConfigurations;

public class IdentityEntityConfiguration : IEntityTypeConfiguration<IdentityEntity>
{
    public void Configure(EntityTypeBuilder<IdentityEntity> builder)
    {
        builder.HasKey(i => i.Id);
        builder.HasIndex(i => i.Email).IsUnique();
    }
}
