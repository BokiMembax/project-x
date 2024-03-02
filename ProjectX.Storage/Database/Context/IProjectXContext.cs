using Microsoft.EntityFrameworkCore;

namespace ProjectX.Storage.Database.Context
{
    public interface IProjectXContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
