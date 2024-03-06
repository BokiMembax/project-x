using Microsoft.EntityFrameworkCore;
using ProjectX.Commands;
using ProjectX.Queries;
using ProjectX.Queries.Database.Context;
using ProjectX.Storage.Database.Context;
using ProjectX.Storage.Repositories.Company;
using ProjectX.Storage.Repositories.Truck;
using ProjectX.Storage.Repositories.User;
using ProjectX.Storage.UnitOfWork;

namespace ProjectX.Api.Registers
{
    public static class RegisterRepositories
    {
        public static IServiceCollection RegisterRepository(this IServiceCollection services)
        {
            services.AddDbContext<ProjectXContext>(dbContextOptions => dbContextOptions.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=ProjectXDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"));

            services.AddDbContext<ProjectXReadOnlyContext>(dbContextOptions => dbContextOptions.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=ProjectXDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"));

            services.AddScoped<IProjectXContext, ProjectXContext>();

            services.AddScoped<IProjectXReadOnlyContext, ProjectXReadOnlyContext>();

            services.AddScoped<ICompanyRepository, CompanyRepository>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ITruckRepository, TruckRepository>();

            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblyContaining<CommandsAssemblyReference>();
                config.RegisterServicesFromAssemblyContaining<QueriesAssemblyReference>();
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
