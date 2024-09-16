using Microsoft.EntityFrameworkCore;
using ProjectX.Queries.Database.Context;
using ProjectX.Queries.Entities.Common;

namespace ProjectX.Queries
{
    public abstract class RepositoryBase
    {
        protected readonly IProjectXReadOnlyContext _projectXReadOnlyContext;

        public RepositoryBase(IProjectXReadOnlyContext projectXReadOnlyContext)
        {
            _projectXReadOnlyContext = projectXReadOnlyContext;
        }

        protected IQueryable<T> All<T>() where T : BaseEntity
        {
            return _projectXReadOnlyContext.Set<T>().Where(x => x.DeletedOn == null).AsNoTracking();
        }
    }
}
