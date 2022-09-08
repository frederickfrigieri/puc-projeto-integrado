using Application._Configuration.MessageBus;
using Autofac;

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
        }
    }
}
