using Shared.EventsMessages.SeedWork;
using System.Threading.Tasks;

namespace Application._Configuration.MessageBus
{
    public interface IMessageBus
    {
        Task Publish<TRequest>(TRequest request) where TRequest : DomainEventMessageBase;
    }
}
