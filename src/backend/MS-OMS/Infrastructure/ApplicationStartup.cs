using Application.Settings;
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

        public static ContainerBuilder InitializeContainer(IServiceCollection services, IConfiguration configuration)
        {
            var containerBuilder = InitializeCustomModules(services, configuration);

            var container = containerBuilder.Build();

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));

            var serviceProvider = new AutofacServiceProvider(container);

            InitializeCustomServices(services, serviceProvider);

            CompositionRoot.SetContainer(container);

            return containerBuilder;
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
            var autenticacaoSetting = configuration.GetSection("Autenticacao").Get<AutenticacaoSetting>();
            var messageBusSettings = configuration.GetSection("MessageBusSettings").Get<MessageBusSettings>();

            container.RegisterModule(new DatabaseModule(connectionString));
            container.RegisterModule(new MediatorModule());
            container.RegisterModule(new DomainModule());
            container.RegisterModule(new ProcessingModule());
            container.RegisterModule(new ServicesModule(autenticacaoSetting));
            container.RegisterModule(new AutoMapperModule(Assemblies.Application));
            container.RegisterModule(new MessageBusModule(messageBusSettings));
        }

        public static void InitializeCustomServices(IServiceCollection services, IServiceProvider serviceProvider = null)
        {
            if (serviceProvider == null)
            {
                services.AddMassTransitHostedService();
            }
        }

        public static void ConfigureLogger(IConfiguration configuration)
        {
            var esConfig = configuration.GetSection("Serilog:Elasticsearch").Get<SerilogElasticsearchConfig>();

            //Log.Logger = new LoggerConfiguration()
            //    .CreateDefaultInstance("MS-OMS")
            //    .WithES(esConfig)
            //    .CreateLogger();
        }
    }
}