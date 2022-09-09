using Application._Configuration.MessageBus;
using MediatR;
using Shared.EventsMessages.WMS;
using System.Threading;
using System.Threading.Tasks;

namespace Application.NotificationHandlers.PedidoAssociadoEstoque
{
    public class PedidoAssociadoEstoqueNotificationHandler : INotificationHandler<PedidoAssociadoEstoqueNotification>
    {
        private readonly IMessageBus _messageBus;

        public PedidoAssociadoEstoqueNotificationHandler(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public async Task Handle(PedidoAssociadoEstoqueNotification notification, CancellationToken cancellationToken)
        {
            var message = new PedidoAssociadoEstoqueEventMessage
            {
                ChaveEstoque = notification.ChaveEstoque,
                ChavePedido = notification.ChavePedido
            };

            await _messageBus.PublishAsync(message, "wms-pedido-associado-estoque");
        }
    }
}
