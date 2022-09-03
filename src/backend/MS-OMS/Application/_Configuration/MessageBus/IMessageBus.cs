using Shared.EventsMessages.SeedWork;
using System.Threading.Tasks;

namespace Application._Configuration.MessageBus
{
    public interface IMessageBus
    {
        Task<TResponse> GetResponse<TRequest, TResponse>(TRequest request) where TRequest : IntegrationEvent
             where TResponse : IntegrationEvent;
        Task Publish<TRequest>(TRequest request) where TRequest : DomainEventMessageBase;
    }
}
