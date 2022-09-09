using Application._Configuration.Commands;
using Domain;
using Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.AssociarPedidoArmazem
{
    public class AssociarPedidoArmazemCommandHandler : ICommandHandler<AssociarPedidoArmazemCommand>
    {
        private readonly IRepository _repository;

        public AssociarPedidoArmazemCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AssociarPedidoArmazemCommand request, CancellationToken cancellationToken)
        {
            var pedidosPendentes = await _repository.ObterPedidosSemArmazem();
            var pedidosPendentesAgrupados = pedidosPendentes.GroupBy(x => x.ChavePedido);

            foreach(var pedidoPendenteAgrupado in pedidosPendentesAgrupados)
            {
                pedidosPendentes = pedidosPendentes
                    .Where(x => x.ChavePedido == pedidoPendenteAgrupado.Key)
                    .ToArray();

                var armazem = await _repository.ObterArmazemMenorQuantidadePedido();

                foreach (var pedido in pedidosPendentes)
                {
                    pedido.AssociarArmazem(armazem);
                }
            }
            return Unit.Value;
        }
    }
}
