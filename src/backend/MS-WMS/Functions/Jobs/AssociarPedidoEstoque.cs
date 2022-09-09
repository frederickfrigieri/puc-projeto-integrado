using Application.Commands.AssociarPedidoEstoque;
using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Functions.Jobs
{
    public class AssociarPedidoEstoque
    {
        private readonly IMediator _mediator;

        public AssociarPedidoEstoque(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("AssociarPedidoEstoque")]
        public async Task Run([TimerTrigger("*/13 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            await _mediator.Send(new AssociarPedidoEstoqueCommand());
        }
    }
}
