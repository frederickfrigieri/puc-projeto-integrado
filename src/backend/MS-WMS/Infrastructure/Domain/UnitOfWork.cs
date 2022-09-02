using Domain._SeedWork;
using Infrastructure.Database;
using Infrastructure.Processing;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CurrentContext _empresaContext;
        private readonly IDomainEventsDispatcher _domainEventsDispatcher;

        public UnitOfWork(
            CurrentContext empresaContext,
            IDomainEventsDispatcher domainEventsDispatcher)
        {
            this._empresaContext = empresaContext;
            this._domainEventsDispatcher = domainEventsDispatcher;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await _domainEventsDispatcher.DispatchEventsAsync();

            return await _empresaContext.SaveChangesAsync(cancellationToken);
        }
    }
}