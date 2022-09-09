using Application._Configuration.Commands;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.AtualizarStatusPedido
{
    public class AtualizarStatusPedidoCommandHandler : ICommandHandler<AtualizarStatusPedidoCommand>
    {
        private readonly IRepository _repository;

        public AtualizarStatusPedidoCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AtualizarStatusPedidoCommand request, CancellationToken cancellationToken)
        {
            var pedido = await _repository.ObterPedidoPorChaveAsync(request.ChavePedido);

            pedido.AtualizarStatus(request.StatusPedido);

            return Unit.Value;
        }
    }
}
