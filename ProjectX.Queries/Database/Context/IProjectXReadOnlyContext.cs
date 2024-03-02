using Microsoft.EntityFrameworkCore;

namespace ProjectX.Queries.Database.Context
{
    public interface IProjectXReadOnlyContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
