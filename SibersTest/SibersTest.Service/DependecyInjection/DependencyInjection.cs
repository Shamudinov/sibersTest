using Microsoft.Extensions.DependencyInjection;
using SibersTest.Service.Services;
using SibersTest.Service.Services.Interfaces;

namespace SibersTest.Service.DependecyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IUTaskService, UTaskService>();

            return services;
        }
    }
}
