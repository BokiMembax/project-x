using ProjectX.Storage.Database.Context;
using ProjectX.Storage.Entities.Common;

namespace ProjectX.Storage.Repositories
{
    public class RepositoryBase
    {
        protected readonly IProjectXContext _projectXContext;

        public RepositoryBase(IProjectXContext projectXContext)
        {
            _projectXContext = projectXContext;
        }

        protected IQueryable<T> All<T>() where T : BaseEntity
        {
            return _projectXContext.Set<T>();
        }

        protected async Task InsertAsync<T>(T entity) where T : BaseEntity
        {
            await _projectXContext.Set<T>().AddAsync(entity);
        }

        protected void Delete<T>(T entity) where T : BaseEntity
        {
            _projectXContext.Set<T>().Remove(entity);
        }
    }
}
