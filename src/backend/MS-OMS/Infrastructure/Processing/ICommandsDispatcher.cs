using System;
using System.Threading.Tasks;

namespace Infrastructure.Processing
{
    public interface ICommandsDispatcher
    {
        Task DispatchCommandAsync(Guid id);
    }
}
