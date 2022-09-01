using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Database
{
    public class CurrentContextFactory : IDesignTimeDbContextFactory<CurrentContext>
    {
        public CurrentContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CurrentContext>();
            var connectionString = @"Data Source=(localdb)\Mssqllocaldb;Initial Catalog=MS-OMS;Integrated Security=True";

            optionsBuilder.UseSqlServer(connectionString, x => x.MigrationsHistoryTable("MigrationsHistory", SchemaNames.Migrations));

            return new CurrentContext(optionsBuilder.Options);
        }
    }
}
