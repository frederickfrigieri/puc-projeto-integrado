using Application._Configuration.MessageBus;
using MassTransit;
using Shared.EventsMessages.SeedWork;
using System.Threading.Tasks;

namespace Infrastructure.Processing
{
    public class MessageBus : IMessageBus
    {
        IBus _bus;

        public MessageBus(IBus bus)
        {
            _bus = bus;
        }

        public async Task<TResponse> GetResponse<TRequest, TResponse>(TRequest request)
            where TRequest : IntegrationEvent
             where TResponse : IntegrationEvent
        {
            var client = _bus.CreateRequestClient<TRequest>();

            var resposta = await client.GetResponse<TResponse>(request);

            return resposta.Message;
        }

        public async Task Publish<TRequest>(TRequest request)
            where TRequest : DomainEventMessageBase
        {
            await _bus.Publish(request);
        }

        public Task PublishAsync<T>(T message, string topicName) where T : DomainEventMessageBase
        {
            throw new System.NotImplementedException();
        }
    }

}