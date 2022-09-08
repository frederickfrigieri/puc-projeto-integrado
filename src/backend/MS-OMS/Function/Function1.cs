using Application._Configuration.Processing;
using Application.Commands.CadastrarProduto;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shared.EventsMessages.WMS;
using System.Threading.Tasks;

namespace Function
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;
        private readonly ICommandsScheduler _commandScheduler;

        public Function1(
            ILogger<Function1> log,
            ICommandsScheduler commandScheduler)
        {
            _logger = log;
            _commandScheduler = commandScheduler;
        }

        [FunctionName("Function1")]
        public async Task Run([ServiceBusTrigger("wms-produto-cadastrado",
            "oms-cadastrar-produto",
            Connection = "ConnectionStringServiceBus")] string message)
        {
            _logger.LogInformation($"C# ServiceBus topic trigger function processed message: {message}");

            var produto = JsonConvert
                .DeserializeObject<ProdutoCadastradoEventMessage>(message);

            var cadastrarProdutoCommand = new CadastrarProdutoCommand
            {
                ChaveParceiro = produto.ChaveParceiro,
                ChaveProduto = produto.ChaveProduto,
                Descricao = produto.Descricao,
                Sku = produto.Sku
            };

            await _commandScheduler.EnqueueAsync(cadastrarProdutoCommand);
        }
    }
}
