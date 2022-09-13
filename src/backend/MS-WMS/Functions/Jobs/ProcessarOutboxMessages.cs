//using System;
//using System.Threading.Tasks;
//using Infrastructure.Processing.Outbox;
//using MediatR;
//using Microsoft.Azure.WebJobs;
//using Microsoft.Azure.WebJobs.Host;
//using Microsoft.Extensions.Logging;

//namespace Functions.Jobs
//{
//    public class ProcessarOutboxMessages
//    {
//        private readonly IMediator _mediator;

//        public ProcessarOutboxMessages(IMediator mediator)
//        {
//            _mediator = mediator;
//        }

//        [FunctionName("ProcessarOutboxMessages")]
//        public async Task Run([TimerTrigger("*/5 * * * * *")]TimerInfo myTimer, ILogger log)
//        {
//            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

//            await _mediator.Send(new ProcessOutboxCommand());
//        }
//    }
//}
