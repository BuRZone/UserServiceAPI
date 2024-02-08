using Microsoft.Extensions.DependencyInjection;
using UserServiceAPI.BLL.Interfaces;
using UserServiceAPI.BLL.Services;

namespace UserServiceAPI.BLL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLogicApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
