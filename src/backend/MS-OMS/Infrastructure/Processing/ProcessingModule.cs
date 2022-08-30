using Autofac;
using Application._Configuration.Commands;
using Application._Configuration.DomainEvents;
using Application._Configuration.Processing;
using Infrastructure.Processing.InternalCommands;
using MediatR;
using System.Linq;

namespace Infrastructure.Processing
{
    public class ProcessingModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DomainEventsDispatcher>()
            .As<IDomainEventsDispatcher>()
            .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(Assemblies.Application)
                .AsClosedTypesOf(typeof(IDomainEventNotification<>)).InstancePerDependency();

            builder.RegisterGenericDecorator(
                typeof(UnitOfWorkCommandHandlerDecorator<>),
                typeof(IRequestHandler<,>),
                context =>
                {
                    return context.ImplementationType.GetInterfaces().Any(t =>
                        t.IsGenericType &&
                        t.GetGenericTypeDefinition() == typeof(ICommandHandler<>));
                });

            builder.RegisterGenericDecorator(
                typeof(UnitOfWorkCommandHandlerWithResultDecorator<,>),
                typeof(IRequestHandler<,>),
                context =>
                {
                    return context.ImplementationType.GetInterfaces().Any(t =>
                        t.IsGenericType &&
                        t.GetGenericTypeDefinition() == typeof(ICommandHandler<,>));
                });

            builder.RegisterGenericDecorator(
                typeof(DomainEventsDispatcherNotificationHandlerDecorator<>),
                typeof(INotificationHandler<>));

            builder.RegisterType<CommandsDispatcher>()
                .As<ICommandsDispatcher>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CommandsScheduler>()
                .As<ICommandsScheduler>()
                .InstancePerLifetimeScope();

        }
    }
}