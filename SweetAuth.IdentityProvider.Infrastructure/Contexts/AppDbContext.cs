using Microsoft.EntityFrameworkCore;

namespace SweetAuth.IdentityProvider.Infrastructure.Contexts
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
