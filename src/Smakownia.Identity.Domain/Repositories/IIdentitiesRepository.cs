using Smakownia.Identity.Domain.Entities;

namespace Smakownia.Identity.Domain.Repositories;

public interface IIdentitiesRepository
{
    Task<IdentityEntity?> GetByEmailOrDefaultAsync(string email, CancellationToken cancellationToken = default);
    void Add(IdentityEntity identity);
}
