using Application._Configuration.Commands;
using System.Threading.Tasks;

namespace Application._Configuration.Processing
{
    public interface ICommandsScheduler
    {
        Task EnqueueAsync<T>(ICommand<T> command);

        Task EnqueueAsync(ICommand command);
    }
}