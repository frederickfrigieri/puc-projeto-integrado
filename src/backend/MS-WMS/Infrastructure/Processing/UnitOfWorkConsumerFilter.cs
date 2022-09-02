using Domain._SeedWork;
using GreenPipes;
using MassTransit;
using System.Threading.Tasks;

namespace Infrastructure.Processing
{
    public class UnitOfWorkConsumerFilter<T> : IFilter<ConsumeContext<T>> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkConsumerFilter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Send(ConsumeContext<T> context, IPipe<ConsumeContext<T>> next)
        {
            await next.Send(context);

            await this._unitOfWork.CommitAsync(context.CancellationToken);
        }

        public void Probe(ProbeContext context)
        {
        }
    }

}