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
    public class PedidoAssociadoEstoque
    {
        private readonly ILogger<PedidoAssociadoEstoque> _logger;
        private readonly ICommandsScheduler _commandsScheduler;

        public PedidoAssociadoEstoque(ILogger<PedidoAssociadoEstoque> log, ICommandsScheduler commandsScheduler)
        {
            _logger = log;
            _commandsScheduler = commandsScheduler;
        }

        [FunctionName("PedidoAssociadoEstoque")]
        public async Task Run([ServiceBusTrigger(
            "wms-pedido-associado-estoque",
            "oms-pedido-associado-estoque",
            Connection = "")]string mySbMsg)
        {
            _logger.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");

            var pedido = JsonConvert
                .DeserializeObject<PedidoAssociadoEstoqueEventMessage>(mySbMsg);

            var command = new AtualizarStatusPedidoCommand
            {
                ChavePedido = pedido.ChavePedido,
                StatusPedido = Domain.Entities.Enums.StatusPedidoEnum.AguardandoEnvio
            };

            await _commandsScheduler.EnqueueAsync(command);
        }
    }
}
