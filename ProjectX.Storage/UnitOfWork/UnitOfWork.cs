using ProjectX.Storage.Database.Context;

namespace ProjectX.Storage.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IProjectXContext _projectXContext;
        public UnitOfWork(IProjectXContext projectXContext)
        {
            _projectXContext = projectXContext;
        }

        public async Task SaveChangesAsync()
        {
            await _projectXContext.SaveChangesAsync();
        }
    }
}
