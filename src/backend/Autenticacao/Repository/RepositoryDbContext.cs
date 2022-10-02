using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class RepositoryDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public RepositoryDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}
