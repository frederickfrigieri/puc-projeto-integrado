using Application._Configuration.MessageBus;
using Autofac;
using GreenPipes;
using MassTransit;

namespace Infrastructure.Processing
{
    public class MessageBusModule : Autofac.Module
    {
        public MessageBusSettings MessageBusSettings { get; }

        public MessageBusModule(MessageBusSettings messageBusSettings)
        {
            MessageBusSettings = messageBusSettings;
        }

        protected override void Load(ContainerBuilder builder)
        {
            if (MessageBusSettings == null) return;

            builder.RegisterType<MessageBus>()
               .As<IMessageBus>()
               .InstancePerLifetimeScope();

            builder.AddMassTransit(x =>
            {
                if (MessageBusSettings.Consumer)
                    x.AddConsumers(Assemblies.Application);

                x.SetKebabCaseEndpointNameFormatter();

                // add the bus to the container
                x.UsingAzureServiceBus((context, cfg) =>
                {
                    cfg.Host(MessageBusSettings.ConnectionString);

                    if (MessageBusSettings.Consumer)
                    {
                        cfg.ReceiveEndpoint("MS-WMS-Queue", ec =>
                        {
                            ec.UseConcurrencyLimit(1);
                            ec.ConfigureConsumers(context);
                            //ec.UseRetry(opt => opt.Incremental(3, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(5)));

                            AutofacFilterExtensions.UseConsumeFilter(ec, typeof(UnitOfWorkConsumerFilter<>), context);
                        });
                    }

                    cfg.ConfigureEndpoints(context);
                });
            });

        }
    }
}
