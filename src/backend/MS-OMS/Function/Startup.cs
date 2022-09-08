using Application._Configuration.Data;
using Application._Configuration.Processing;
using Infrastructure.Database;
using Infrastructure.Processing;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Function.Startup))]
namespace Function
{

    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=MS-OMS;Integrated Security=True;MultipleActiveResultSets=True";

            builder.Services.AddScoped<ICommandsScheduler, CommandsScheduler>();

            builder.Services.AddSingleton<ISqlConnectionFactory>((s) =>
            {
                return new SqlConnectionFactory(connectionString);
            });
        }
    }
}
