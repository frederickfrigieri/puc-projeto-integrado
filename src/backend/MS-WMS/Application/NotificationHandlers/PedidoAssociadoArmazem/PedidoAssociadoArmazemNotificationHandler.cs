using Application._Configuration.MessageBus;
using MediatR;
using Shared.EventsMessages.WMS;
using System.Threading;
using System.Threading.Tasks;

namespace Application.NotificationHandlers.PedidoAssociadoArmazem
{
    public class PedidoAssociadoArmazemNotificationHandler : INotificationHandler<PedidoAssociadoArmazemNotification>
    {
        private readonly IMessageBus _messageBus;

        public PedidoAssociadoArmazemNotificationHandler(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public async Task Handle(PedidoAssociadoArmazemNotification notification, CancellationToken cancellationToken)
        {
            var message = new PedidoAssociadoArmazemEventMessage
            {
                ChaveArmazem = notification.ChaveArmazem,
                ChavePedido = notification.ChavePedido
            };

            await _messageBus.PublishAsync(message, "wms-pedido-associado-armazem");
        }
    }
}
