using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Database
{
    public class CurrentContextFactory : IDesignTimeDbContextFactory<CurrentContext>
    {
        public CurrentContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CurrentContext>();
            //var connectionString = @"Data Source=(localdb)\Mssqllocaldb;Initial Catalog=MS-OMS;Integrated Security=True";
            var connectionString = @"Server=tcp:deliverystore-db.database.windows.net,1433;Initial Catalog=deliverystore;
                                    Persist Security Info=False;User ID=deliverystore;Password=123@Trocar;
                                    MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


            optionsBuilder.UseSqlServer(connectionString, x => x.MigrationsHistoryTable("MigrationsHistory", SchemaNames.OMS));

            return new CurrentContext(optionsBuilder.Options);
        }
    }
}
