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
                        //// all of these are optional!!
                        //e.PrefetchCount = 100;

                        //// number of "threads" to run concurrently
                        //e.MaxConcurrentCalls = 100;

                        //// default, but shown for example
                        //e.LockDuration = TimeSpan.FromMinutes(5);

                        //// lock will be renewed up to 30 minutes
                        //e.MaxAutoRenewDuration = TimeSpan.FromMinutes(30);

                        e.UseConcurrencyLimit(1);
                        e.ConfigureConsumers(context);
                        e.UseRetry(opt => opt.Incremental(3, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(5)));

                    });
                });

                // add the bus to the container
                //x.UsingRabbitMq((context, cfg) =>
                //{
                //    cfg.Host(new Uri(MessageBusSettings.ConnectionString));

                //    if (MessageBusSettings.Consumer)
                //    {
                //        cfg.ReceiveEndpoint("MS-OMS-Queue", ec =>
                //        {
                //            ec.UseConcurrencyLimit(1);
                //            ec.ConfigureConsumers(context);
                //            ec.UseRetry(opt => opt.Incremental(3, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(5)));

                //            AutofacFilterExtensions.UseConsumeFilter(ec, typeof(UnitOfWorkConsumerFilter<>), context);
                //        });
                //    }
                //});
            });
        }
    }
}
