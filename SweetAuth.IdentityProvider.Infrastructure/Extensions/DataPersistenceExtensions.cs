using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SweetAuth.IdentityProvider.Infrastructure.Contexts;
using SweetAuth.IdentityProvider.Infrastructure.Interfaces;
using SweetAuth.IdentityProvider.Infrastructure.UoW;

namespace IdentityProvider.Infrastructure.Extensions
{
    public static class DataPersistenceExtensions
    {
        public static IServiceCollection AddDatabases(this IServiceCollection s, IConfigurationManager configurationManager)
        {
            s.AddDbContext<AppDbContext>(opt =>
            {
                string? connectionString = configurationManager.GetConnectionString("AppDb");

                opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            });

            return s;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection s)
        {
            s.AddScoped<IUnitOfWork, UnitOfWork>();
            return s;
        }
    }
}
