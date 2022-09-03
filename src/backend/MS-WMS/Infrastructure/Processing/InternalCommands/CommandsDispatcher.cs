using Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Processing.InternalCommands
{
    public class CommandsDispatcher : ICommandsDispatcher
    {
        private readonly IMediator _mediator;
        private readonly CurrentContext _currentContext;

        public CommandsDispatcher(
            IMediator mediator,
            CurrentContext currentContext)
        {
            this._mediator = mediator;
            this._currentContext = currentContext;
        }

        public async Task DispatchCommandAsync(Guid id)
        {
            var internalCommand = await _currentContext.InternalCommands.SingleOrDefaultAsync(x => x.Id == id);

            Type type = Assemblies.Application.GetType(internalCommand.Type);
            dynamic command = JsonConvert.DeserializeObject(internalCommand.Data, type);

            internalCommand.ProcessedDate = DateTime.UtcNow;

            await this._mediator.Send(command);
        }
    }
}