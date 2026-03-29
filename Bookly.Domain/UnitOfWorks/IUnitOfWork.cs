namespace Bookly.Domain.UnitOfWorks;
public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cacnellationToken = default);
}
