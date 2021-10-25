using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUCAL.Application.Core.Interfaces;
using NUCAL.Persistence.Contexts;

namespace NUCAL.Persistence.Extensions
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistenceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
