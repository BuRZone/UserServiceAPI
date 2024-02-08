using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserServiceAPI.DAL.Data;
using UserServiceAPI.DAL.Interfaces;
using UserServiceAPI.DAL.Repositories;

namespace UserServiceAPI.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDbApplication(this IServiceCollection services, IConfiguration configuration)
        {
            var conectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(o => o.UseSqlite(conectionString));
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}