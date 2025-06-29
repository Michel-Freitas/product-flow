using Microsoft.EntityFrameworkCore;
using ProductFlow.Core.Domain.Entity;

namespace ProductFlow.Core.Infra.Dao.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<FileEntity> File { get; set; }
        public DbSet<UserEntity> User { get; set; }
    }
}
