using MediatR;

namespace Application._Configuration.Queries
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}