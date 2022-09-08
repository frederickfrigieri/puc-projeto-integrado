using Application._Configuration.Data;
using Application._Configuration.Processing;
using Infrastructure.Database;
using Infrastructure.Processing;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Functions.Startup))]
namespace Functions
{

    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=MS-WMS;Integrated Security=True;MultipleActiveResultSets=True";

            builder.Services.AddScoped<ICommandsScheduler, CommandsScheduler>();

            builder.Services.AddSingleton<ISqlConnectionFactory>((s) =>
            {
                return new SqlConnectionFactory(connectionString);
            });


            //ApplicationStartup.InitializeCustomServices(builder.Services);

            //builder.RegisterBuildCallback(c => container = c);
            //ApplicationStartup.InitializeContainerModules(builder, hostContext.Configuration);

        }
    }
}
