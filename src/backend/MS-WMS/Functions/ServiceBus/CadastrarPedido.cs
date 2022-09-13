//using Application._Configuration.Processing;
//using Application.Commands.CadastrarPedido;
//using Microsoft.Azure.WebJobs;
//using Microsoft.Extensions.Logging;
//using Newtonsoft.Json;
//using Shared.EventsMessages.OMS;
//using System.Threading.Tasks;

//namespace Functions.ServiceBus
//{
//    public class CadastrarPedido
//    {
//        private readonly ILogger<CadastrarPedido> _logger;
//        private readonly ICommandsScheduler _commandScheduler;

//        public CadastrarPedido(
//            ILogger<CadastrarPedido> log,
//            ICommandsScheduler commandScheduler
//            )
//        {
//            _logger = log;
//            _commandScheduler = commandScheduler;
//        }



//        [FunctionName("CadastrarPedido")]
//        public async Task Run([ServiceBusTrigger("oms-pedido-cadastrado", "wms-cadastrar-pedido", Connection = "ConnectionStringServiceBus")] string message)
//        {
//            _logger.LogInformation($"C# ServiceBus topic trigger function processed message: {message}");

//            var pedido = JsonConvert
//                .DeserializeObject<PedidoCadastradoEventMessage>(message);

//            var cadastrarPedidoCommand = new CadastrarPedidoCommand(
//                pedido.ChaveParceiro,
//                pedido.ChavePedido
//                );

//            foreach (var item in pedido.Itens)
//            {
//                cadastrarPedidoCommand.Itens.Add(new CadastrarItemPedidoCommand
//                {
//                    ChaveItemPedido = item.ChaveItem,
//                    ChaveProduto = item.ChaveProduto,
//                    Quantidade = item.Quantidade
//                });
//            }

//            await _commandScheduler.EnqueueAsync(cadastrarPedidoCommand);
//        }
//    }
//}
