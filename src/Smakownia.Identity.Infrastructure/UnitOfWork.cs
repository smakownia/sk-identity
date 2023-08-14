using Smakownia.Identity.Domain;

namespace Smakownia.Identity.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly IdentityContext _identityContext;

    public UnitOfWork(IdentityContext identityContext)
    {
        _identityContext = identityContext;
    }

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await _identityContext.SaveChangesAsync(cancellationToken);
    }
}
