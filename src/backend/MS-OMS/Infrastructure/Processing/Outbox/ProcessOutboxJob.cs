using Hangfire;
using System.Threading.Tasks;

namespace Infrastructure.Processing.Outbox
{
    public class ProcessOutboxJob
    {
        public ProcessOutboxJob()
        {
        }

        public async Task Run(IJobCancellationToken token)
        {
            await CommandsExecutor.Execute(new ProcessOutboxCommand());
        }
    }
}