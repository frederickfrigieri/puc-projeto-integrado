using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Database
{
    public class CurrentContextFactory : IDesignTimeDbContextFactory<CurrentContext>
    {
        public CurrentContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CurrentContext>();
            var connectionString = @"Data Source=(localdb)\Mssqllocaldb;Initial Catalog=DeliveryStore;Integrated Security=True";

            optionsBuilder.UseSqlServer(connectionString, x => x.MigrationsHistoryTable("MigrationsHistory", SchemaNames.OMS));

            return new CurrentContext(optionsBuilder.Options);
        }
    }
}
