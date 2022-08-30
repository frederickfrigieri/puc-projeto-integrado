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
        private readonly CurrentContext _omsContext;

        public CommandsDispatcher(
            IMediator mediator,
            CurrentContext omsContext)
        {
            this._mediator = mediator;
            this._omsContext = omsContext;
        }

        public async Task DispatchCommandAsync(Guid id)
        {
            var internalCommand = await _omsContext.InternalCommands.SingleOrDefaultAsync(x => x.Id == id);

            Type type = Assemblies.Application.GetType(internalCommand.Type);
            dynamic command = JsonConvert.DeserializeObject(internalCommand.Data, type);

            internalCommand.ProcessedDate = DateTime.UtcNow;

            await this._mediator.Send(command);
        }
    }
}