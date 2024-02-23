using Microsoft.EntityFrameworkCore;
using N5Challenge.Domain.Permissions;
using N5Challenge.Domain.PermissionTypes;

namespace N5Challenge.Infrastructure.Common
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Permission> Permissions { get; set; } = null!;
        public DbSet<PermissionType> PermissionTypes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
