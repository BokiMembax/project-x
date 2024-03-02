using Microsoft.EntityFrameworkCore;
using ProjectX.Queries.Database.Context;
using ProjectX.Queries.Entities.Common;

namespace ProjectX.Queries
{
    public class RepositoryBase
    {
        protected readonly IProjectXReadOnlyContext _projectXReadOnlyContext;

        public RepositoryBase(IProjectXReadOnlyContext projectXReadOnlyContext)
        {
            _projectXReadOnlyContext = projectXReadOnlyContext;
        }

        protected IQueryable<T> All<T>() where T : BaseEntity
        {
            // I
            // return _projectXReadOnlyContext.Set<T>();

            // II
            return _projectXReadOnlyContext.Set<T>().Where(x => x.DeletedOn == null).AsNoTracking();
        }
    }
}
