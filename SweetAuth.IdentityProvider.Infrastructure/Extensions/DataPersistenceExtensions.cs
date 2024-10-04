using IdentityProvider.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
    }
}
