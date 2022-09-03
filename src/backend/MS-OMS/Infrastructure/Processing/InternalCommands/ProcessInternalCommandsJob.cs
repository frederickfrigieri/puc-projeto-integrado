using Hangfire;
using System.Threading.Tasks;

namespace Infrastructure.Processing.InternalCommands
{
    public class ProcessInternalCommandsJob
    {
        public ProcessInternalCommandsJob()
        {
        }

        public async Task Run(IJobCancellationToken token)
        {
            await CommandsExecutor.Execute(new ProcessInternalCommandsCommand());
        }
    }
}
