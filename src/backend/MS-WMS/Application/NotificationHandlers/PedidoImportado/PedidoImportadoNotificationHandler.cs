using Application._Configuration.Processing;
using Application.Commands.AssociarPedidoArmazem;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.NotificationHandlers.PedidoImportado
{
    public class PedidoImportadoNotificationHandler : INotificationHandler<PedidoImportadoNotification>
    {
        private readonly ICommandsScheduler _commandsScheduler;

        public PedidoImportadoNotificationHandler(ICommandsScheduler commandsScheduler)
        {
            _commandsScheduler = commandsScheduler;
        }

        public Task Handle(PedidoImportadoNotification notification, CancellationToken cancellationToken)
        {
            var command = new AssociarPedidoArmazemCommand(notification.ChavePedido);

            _commandsScheduler.EnqueueAsync(command);

            return Task.CompletedTask;
        }
    }
}
