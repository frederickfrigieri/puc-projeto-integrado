using Application._Configuration.Processing;
using Application.Commands.CadastrarPedido;
using MassTransit;
using Shared.EventsMessages.OMS;
using System.Threading.Tasks;

namespace Application.ConsumerHandlers
{
    public class CadastrarPedidoConsumer : IConsumer<PedidoCadastradoEventMessage>
    {
        private ICommandsScheduler _commandsScheduler;

        public CadastrarPedidoConsumer(ICommandsScheduler commandsScheduler)
        {
            _commandsScheduler = commandsScheduler;
        }

        public async Task Consume(ConsumeContext<PedidoCadastradoEventMessage> context)
        {
            var evento = context.Message;
            var pedidoCommand = new CadastrarPedidoCommand(evento.ChaveParceiro, evento.ChavePedido);

            foreach (var item in evento.Itens)
            {
                var itemCommand = new CadastrarItemPedidoCommand
                {
                    ChaveItemPedido = item.ChaveItem,
                    ChaveProduto = item.ChaveProduto,
                    Quantidade = item.Quantidade
                };

                pedidoCommand.Itens.Add(itemCommand);
            }

            if (pedidoCommand.Itens.Count > 0)
                await _commandsScheduler.EnqueueAsync(pedidoCommand);
        }
    }
}
