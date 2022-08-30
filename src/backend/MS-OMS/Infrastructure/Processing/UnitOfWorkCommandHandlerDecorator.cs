using Application._Configuration.Commands;
using Domain._SeedWork;
using Infrastructure.Database;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Processing
{
    public class UnitOfWorkCommandHandlerDecorator<T> : ICommandHandler<T> where T : ICommand
    {
        private readonly ICommandHandler<T> _decorated;

        private readonly IUnitOfWork _unitOfWork;

        private readonly CurrentContext _omsContext;

        public UnitOfWorkCommandHandlerDecorator(
            ICommandHandler<T> decorated,
            IUnitOfWork unitOfWork,
            CurrentContext omsContext)
        {
            _decorated = decorated;
            _unitOfWork = unitOfWork;
            _omsContext = omsContext;
        }

        public async Task<Unit> Handle(T command, CancellationToken cancellationToken)
        {
            await _decorated.Handle(command, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}