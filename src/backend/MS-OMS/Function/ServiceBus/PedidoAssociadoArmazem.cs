using System;
using System.Threading.Tasks;
using Application._Configuration.Processing;
using Application.Commands.AtualizarStatusPedido;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shared.EventsMessages.WMS;

namespace Function.ServiceBus
{
    public class PedidoAssociadoArmazem
    {
        private readonly ILogger<PedidoAssociadoArmazem> _logger;
        private readonly ICommandsScheduler _commandsScheduler;

        public PedidoAssociadoArmazem(
            ILogger<PedidoAssociadoArmazem> log, 
            ICommandsScheduler commandsScheduler)
        {
            _logger = log;
            _commandsScheduler = commandsScheduler;
        }

        [FunctionName("PedidoAssociadoArmazem")]
        public async Task Run([ServiceBusTrigger(
            "wms-pedido-associado-armazem",
            "oms-pedido-associado-armazem",
            Connection = "ConnectionStringServiceBus")]string message)
        {
            _logger.LogInformation($"C# ServiceBus topic trigger function processed message: {message}");

            var pedido = JsonConvert
                .DeserializeObject<PedidoAssociadoArmazemEventMessage>(message);

            var command = new AtualizarStatusPedidoCommand
            {
                ChavePedido = pedido.ChavePedido,
                StatusPedido = Domain.Entities.Enums.StatusPedidoEnum.PendenteEstoque
            };

            await _commandsScheduler.EnqueueAsync(command);
        }
    }
}
