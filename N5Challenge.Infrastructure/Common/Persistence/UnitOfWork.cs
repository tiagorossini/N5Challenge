using N5Challenge.Application.Common.Interfaces;

namespace N5Challenge.Infrastructure.Common.Persistence
{
    internal sealed class UnitOfWork(AppDbContext _dbContext) : IUnitOfWork
    {
        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
