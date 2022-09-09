using Application._Configuration.MessageBus;
using Autofac;

namespace Infrastructure.Processing
{
    public class MessageBusModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MessageBus>()
               .As<IMessageBus>()
               .InstancePerLifetimeScope();
        }
    }
}
