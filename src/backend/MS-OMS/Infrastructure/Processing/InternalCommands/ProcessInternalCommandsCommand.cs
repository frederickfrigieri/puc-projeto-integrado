using Application._Configuration.Commands;
using Infrastructure.Processing.Outbox;
using MediatR;

namespace Infrastructure.Processing.InternalCommands
{
    public class ProcessInternalCommandsCommand : CommandBase<Unit>, IRecurringCommand
    {

    }
}