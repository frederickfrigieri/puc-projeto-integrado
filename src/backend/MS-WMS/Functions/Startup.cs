//using Application._Configuration.Data;
//using Application._Configuration.Processing;
//using Infrastructure;
//using Infrastructure.Database;
//using Infrastructure.Processing;
//using Infrastructure.Processing.Outbox;
//using MediatR;
//using Microsoft.Azure.Functions.Extensions.DependencyInjection;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;

//[assembly: FunctionsStartup(typeof(Functions.Startup))]
//namespace Functions
//{

//    public class Startup : FunctionsStartup
//    {
//        public override void Configure(IFunctionsHostBuilder builder)
//        {
//            var configuration = BuildConfiguration(builder.GetContext().ApplicationRootPath);
//            var connectionString = configuration.GetConnectionString("ConnectionString");

//            builder.Services.AddSingleton<ISqlConnectionFactory>((s) =>
//            {
//                return new SqlConnectionFactory(connectionString);
//            });

//            builder.Services.AddScoped<ICommandsScheduler, CommandsScheduler>();
//            builder.Services.AddMediatR(typeof(ProcessOutboxCommand));

//            ApplicationStartup.Initialize(builder.Services, configuration);

//        }
//        private IConfiguration BuildConfiguration(string applicationRootPath)
//        {
//            var config =
//                new ConfigurationBuilder()
//                    .SetBasePath(applicationRootPath)
//                    .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
//                    .AddJsonFile("settings.json", optional: true, reloadOnChange: true)
//                    .AddEnvironmentVariables()
//                    .Build();

//            return config;
//        }
//    }
//}
