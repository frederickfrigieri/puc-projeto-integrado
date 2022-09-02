using Application._Configuration.MessageBus;
using Domain;
using EventMessage.OMS;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.NotificationHandlers.PedidoCadastrado
{
    public class PedidoCadastradoNotificationHandler : INotificationHandler<PedidoCadastradoNotification>
    {
        private readonly IRepository _repository;
        private readonly IMessageBus _messageBus;

        public PedidoCadastradoNotificationHandler(IRepository repository, IMessageBus messageBus)
        {
            _repository = repository;
            _messageBus = messageBus;
        }

        public async Task Handle(PedidoCadastradoNotification notification, CancellationToken cancellationToken)
        {
            var pedido = await _repository.ObterPedidoPorChaveAsync(notification.ChavePedido, new string[] { "Itens", "Itens.Produto" });

            var itensMessage = new List<ItemPedidoCadastradoEventMessage>();

            if (pedido != null && pedido.Itens.Count > 0)
            {
                foreach (var item in pedido.Itens)
                {
                    var itemMessage = new ItemPedidoCadastradoEventMessage
                    {
                        ChaveItem = item.Chave,
                        ChaveProduto = item.Produto.Chave,
                        Quantidade = item.Quantidade
                    };
                    itensMessage.Add(itemMessage);
                }
            }

            if (itensMessage.Count > 0)
            {
                var message = new PedidoCadastradoEventMessage(pedido.Chave, itensMessage);

                await _messageBus.Publish(message);
            }
        }
    }
}
