using Microsoft.EntityFrameworkCore;
using Smakownia.Identity.Domain.Entities;
using Smakownia.Identity.Domain.Repositories;

namespace Smakownia.Identity.Infrastructure.Repositories;

public class IdentitiesRepository : IIdentitiesRepository
{
    private readonly IdentityContext _identityContext;

    public IdentitiesRepository(IdentityContext identityContext)
    {
        _identityContext = identityContext;
    }

    public async Task<IdentityEntity?> GetByEmailOrDefaultAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _identityContext.Identities.Where(i => i.Email == email).FirstOrDefaultAsync(cancellationToken);
    }

    public void Add(IdentityEntity identity)
    {
        _identityContext.Identities.Add(identity);
    }
}
