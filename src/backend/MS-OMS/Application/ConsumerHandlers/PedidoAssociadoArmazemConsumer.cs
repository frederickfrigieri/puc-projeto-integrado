using Application._Configuration.Processing;
using Application.Commands.AssociarPedidoArmazem;
using MassTransit;
using Shared.EventsMessages.WMS;
using System.Threading.Tasks;

namespace Application.ConsumerHandlers
{
    public class PedidoAssociadoArmazemConsumer : IConsumer<PedidoAssociadoArmazemEventMessage>
    {
        private readonly ICommandsScheduler _commandsScheduler;

        public PedidoAssociadoArmazemConsumer(ICommandsScheduler commandsScheduler)
        {
            _commandsScheduler = commandsScheduler;
        }

        public async Task Consume(ConsumeContext<PedidoAssociadoArmazemEventMessage> context)
        {
            var message = context.Message;
            var command = new AssociarPedidoArmazemCommand(message.ChavePedido, message.ChaveArmazem);
            
            await _commandsScheduler.EnqueueAsync(command);
        }
    }
}
