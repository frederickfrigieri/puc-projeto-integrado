using Infrastructure.Processing.Outbox;
using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;

namespace Function.Timers
{
    public class ProcessarOutboxMessages
    {
        private readonly IMediator _mediator;

        public ProcessarOutboxMessages(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName("ProcessarOutbox")]
        public void Run([TimerTrigger("*/10 * * * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            _mediator.Send(new ProcessOutboxCommand());
        }
    }
}
