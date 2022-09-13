using Application._Configuration.MessageBus;
using MediatR;
using Shared.EventsMessages.WMS;
using System.Threading;
using System.Threading.Tasks;

namespace Application.NotificationHandlers.ProdutoCadastrado
{

    public class ProdutoCadastradoNotificationHandler : INotificationHandler<ProdutoCadastradoNotification>
    {
        private readonly IMessageBus _messageBus;

        public ProdutoCadastradoNotificationHandler(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public async Task Handle(ProdutoCadastradoNotification notification, CancellationToken cancellationToken)
        {
            var message = new ProdutoCadastradoEventMessage
            {
                ChaveParceiro = notification.ChaveParceiro,
                ChaveProduto = notification.ChaveProduto,
                Descricao = notification.Descricao,
                Sku = notification.Sku
            };

            await _messageBus.Publish(message);
        }
    }

}
