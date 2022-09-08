using Application._Configuration.Processing;
using Application.Commands.CadastrarPedido;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shared.EventsMessages.OMS;
using System.Threading.Tasks;

namespace Functions
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;
        private readonly ICommandsScheduler _commandScheduler;

        public Function1(
            ILogger<Function1> log,
            ICommandsScheduler commandScheduler
            )
        {
            _logger = log;
            _commandScheduler = commandScheduler;
        }



        [FunctionName("Function1")]
        public async Task Run([ServiceBusTrigger("oms-pedido-cadastrado", "wms-cadastrar-pedido", Connection = "ConnectionStringServiceBus")] string message)
        {
            _logger.LogInformation($"C# ServiceBus topic trigger function processed message: {message}");

            var pedido = JsonConvert
                .DeserializeObject<PedidoCadastradoEventMessage>(message);

            var cadastrarPedidoCommand = new CadastrarPedidoCommand(
                pedido.ChaveParceiro,
                pedido.ChavePedido
                );

            foreach (var item in pedido.Itens)
            {
                cadastrarPedidoCommand.Itens.Add(new CadastrarItemPedidoCommand
                {
                    ChaveItemPedido = item.ChaveItem,
                    ChaveProduto = item.ChaveProduto,
                    Quantidade = item.Quantidade
                });
            }

            await _commandScheduler.EnqueueAsync(cadastrarPedidoCommand);
        }
    }
}
