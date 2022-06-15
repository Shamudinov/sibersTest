using Microsoft.Extensions.DependencyInjection;
using SibersTest.DAL.Repositories;
using SibersTest.DAL.Repositories.Interfaces;

namespace SibersTest.DAL.DependecyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection service)
        {
            service.AddTransient<IProjectRepository, ProjectRepository>();
            service.AddTransient<IAccountRepository, AccountRepository>();
            service.AddTransient<IProjectUserRepository, ProjectUserRepository>();
            service.AddTransient<IUTaskRepository, UTaskRepository>();
            service.AddTransient<IUnitOfWork, UnitOfWork>();
            return service;
        }
    }
}
