using Application._Configuration.Commands;
using Domain._SeedWork;
using Infrastructure.Database;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Processing
{
    public class UnitOfWorkCommandHandlerWithResultDecorator<T, TResult> : ICommandHandler<T, TResult> where T : ICommand<TResult>
    {
        private readonly ICommandHandler<T, TResult> _decorated;

        private readonly IUnitOfWork _unitOfWork;

        private readonly CurrentContext _omsContext;

        public UnitOfWorkCommandHandlerWithResultDecorator(
            ICommandHandler<T, TResult> decorated,
            IUnitOfWork unitOfWork,
            CurrentContext omsContext)
        {
            _decorated = decorated;
            _unitOfWork = unitOfWork;
            _omsContext = omsContext;
        }

        public async Task<TResult> Handle(T command, CancellationToken cancellationToken)
        {
            var result = await this._decorated.Handle(command, cancellationToken);

            await this._unitOfWork.CommitAsync(cancellationToken);

            return result;
        }
    }
}