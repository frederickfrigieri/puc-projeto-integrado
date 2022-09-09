using Infrastructure.Processing.InternalCommands;
using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Functions.Jobs
{
    public class ProcessarInternalCommands
    {
        private readonly IMediator _mediator;

        public ProcessarInternalCommands(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("ProcessarInternalCommands")]
        public async Task Run([TimerTrigger("*/7 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            await _mediator.Send(new ProcessInternalCommandsCommand());

        }
    }
}
