using Application._Configuration.Processing;
using Application.Commands.CadastrarProduto;
using MassTransit;
using Shared.EventsMessages.WMS;
using System.Threading.Tasks;

namespace Application.ConsumerHandlers
{
    public class CadastrarProdutoConsumer : IConsumer<ProdutoCadastradoEventMessage>
    {
        private readonly ICommandsScheduler _commandsScheduler;

        public CadastrarProdutoConsumer(ICommandsScheduler commandsScheduler)
        {
            _commandsScheduler = commandsScheduler;
        }

        public async Task Consume(ConsumeContext<ProdutoCadastradoEventMessage> context)
        {
            var evento = context.Message;

            var command = new CadastrarProdutoCommand
            {
                ChaveParceiro = evento.ChaveParceiro,
                Descricao = evento.Descricao,
                Sku = evento.Sku,
                ChaveProduto = evento.ChaveProduto
            };

            await _commandsScheduler.EnqueueAsync(command);
        }
    }
}
