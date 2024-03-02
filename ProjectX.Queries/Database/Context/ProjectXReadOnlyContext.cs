using Microsoft.EntityFrameworkCore;
using ProjectX.Queries.Database.Configuration;

namespace ProjectX.Queries.Database.Context
{
    public class ProjectXReadOnlyContext : DbContext, IProjectXReadOnlyContext
    {
        public ProjectXReadOnlyContext(DbContextOptions<ProjectXReadOnlyContext> options) : base(options)
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
