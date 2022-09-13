using Infrastructure.Processing.InternalCommands;
using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;

namespace Function.Timers
{
    public class ProcessarInternalCommands
    {
        private readonly IMediator _mediator;

        public ProcessarInternalCommands(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("ProcessarInternalCommands")]
        public void Run([TimerTrigger("*/10 * * * * *", RunOnStartup = false)] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            _mediator.Send(new ProcessInternalCommandsCommand());
        }
    }
}
