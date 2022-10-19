using Application._Configuration.Commands;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.AssociarPedidoArmazem
{
    public class AssociarPedidoArmazemCommandHandler : ICommandHandler<AssociarPedidoArmazemCommand, Unit>
    {
        private readonly IRepository _repository;

        public AssociarPedidoArmazemCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AssociarPedidoArmazemCommand request, CancellationToken cancellationToken)
        {
            var pedido = await _repository.ObterPedidoPorChaveAsync(request.ChavePedido);

            pedido.AssociarArmazem(request.ChaveArmazem);

            return Unit.Value;
        }
    }
}
