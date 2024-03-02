using Microsoft.EntityFrameworkCore;
using ProjectX.Storage.Database.Configuration;

namespace ProjectX.Storage.Database.Context
{
    public class ProjectXContext : DbContext, IProjectXContext
    {
        public ProjectXContext(DbContextOptions<ProjectXContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ApplyGlobalFilters(modelBuilder);

            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
