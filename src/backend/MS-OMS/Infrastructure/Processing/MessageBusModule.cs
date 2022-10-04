using Application._Configuration.MessageBus;
using Application.ConsumerHandlers;
using Autofac;
using GreenPipes;
using MassTransit;
using System;

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
                x.SetKebabCaseEndpointNameFormatter();

                if (MessageBusSettings.Consumer)
                    //x.AddConsumer<CadastrarProdutoConsumer>();
                    x.AddConsumers(Assemblies.Application);

                x.UsingAzureServiceBus((context, cfg) =>
                {
                    cfg.Host("Endpoint=sb://tcc-puc-minas-delivery-store.servicebus.windows.net/;SharedAccessKeyName=DeliveryStoreServiceBus;SharedAccessKey=TNdBNd6fXqCyZL+646cAjSNXp3uSAlwwWFSdIxCBCLM=");
                    cfg.ReceiveEndpoint("ms-oms-produto", e =>
                    {
                        e.UseConcurrencyLimit(1);
                        e.ConfigureConsumers(context);
                        e.UseRetry(opt => opt.Incremental(3, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(5)));
                        AutofacFilterExtensions.UseConsumeFilter(e, typeof(UnitOfWorkConsumerFilter<>), context);
                    });
                });
            });
        }
    }
}
