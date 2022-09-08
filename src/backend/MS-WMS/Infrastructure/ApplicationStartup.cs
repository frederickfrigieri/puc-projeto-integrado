using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using Infrastructure.AutoMapper;
using Infrastructure.Database;
using Infrastructure.Domain;
using Infrastructure.Processing;
using Infrastructure.Services;
using MassTransit;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog.RequestResponseExtension.Models;
using System;
using System.Globalization;
using System.IO;

namespace Infrastructure
{
    public class ApplicationStartup
    {
        private static MessageBusSettings _messageBusSettings;
        public static IConfiguration Configuration { get; set; }


        public static IConfigurationBuilder InitializeConfiguration(IConfigurationBuilder configuration = null)
        {
            var cultureInfo = new CultureInfo("en-US");

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            if (configuration == null) configuration = new ConfigurationBuilder();

            return configuration
                       .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                       .AddJsonFile("appsettings.Development.json", optional: true);
        }

        public static IServiceProvider Initialize(IServiceCollection services, IConfiguration configuration)
        {
            var containerBuilder = InitializeCustomModules(services, configuration);

            var container = containerBuilder.Build();

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));

            var serviceProvider = new AutofacServiceProvider(container);

            InitializeCustomServices(services, serviceProvider);

            CompositionRoot.SetContainer(container);

            return serviceProvider;
        }

        public static ContainerBuilder InitializeCustomModules(IServiceCollection services, IConfiguration configuration)
        {
            var container = new ContainerBuilder();

            container.Populate(services);

            InitializeContainerModules(container, configuration);

            return container;
        }

        public static void InitializeContainerModules(ContainerBuilder container, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            _messageBusSettings = configuration.GetSection("MessageBusSettings").Get<MessageBusSettings>();

            container.RegisterModule(new DatabaseModule(connectionString));
            container.RegisterModule(new MediatorModule());
            container.RegisterModule(new DomainModule());
            container.RegisterModule(new ProcessingModule());
            container.RegisterModule(new ServicesModule());
            container.RegisterModule(new AutoMapperModule(Assemblies.Application));
            container.RegisterModule(new MessageBusModule(_messageBusSettings));
        }

        public static void InitializeCustomServices(IServiceCollection services, IServiceProvider serviceProvider = null)
        {
            if (serviceProvider == null)
            {
                services.AddMassTransitHostedService();
            }
            //else
            //{
            //    var bc = serviceProvider.GetService<IBusControl>();
            //    bc.Start();
            //}
        }

        public static void ConfigureLogger(IConfiguration configuration)
        {
            var esConfig = configuration.GetSection("Serilog:Elasticsearch").Get<SerilogElasticsearchConfig>();

            //Log.Logger = new LoggerConfiguration()
            //    .CreateDefaultInstance("MS-WMS")
            //    .WithES(esConfig)
            //    .CreateLogger();
        }
    }
}