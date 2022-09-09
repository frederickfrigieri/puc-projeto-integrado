using Application.Commands.AssociarPedidoArmazem;
using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Functions.Jobs
{
    public class AssociarPedidoArmazem
    {
        private readonly IMediator _mediator;

        public AssociarPedidoArmazem(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("AssociarPedidoArmazem")]
        public async Task Run([TimerTrigger("*/15 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            await _mediator.Send(new AssociarPedidoArmazemCommand());
        }
    }
}
