using Autofac;
using Autofac.Extensions.DependencyInjection;
using Infrastructure;
using Microsoft.Extensions.Hosting;

namespace Worker
{
    public class Program
    {
        private static ILifetimeScope container;

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureHostConfiguration(configHost =>
                {
                    ApplicationStartup.InitializeConfiguration(configHost);
                })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureLogging((hostContext, loggingBuilder) =>
                {
                    ApplicationStartup.ConfigureLogger(hostContext.Configuration);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    ApplicationStartup.InitializeCustomServices(services);
                })
                .ConfigureContainer<ContainerBuilder>((hostContext, builder) =>
                {
                    builder.RegisterBuildCallback(c => container = c);
                    ApplicationStartup.InitializeContainerModules(builder, hostContext.Configuration);
                });
    }
}
