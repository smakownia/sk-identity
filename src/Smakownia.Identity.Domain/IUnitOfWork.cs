namespace Smakownia.Identity.Domain;

public interface IUnitOfWork
{
    Task CommitAsync(CancellationToken cancellationToken = default);
}
