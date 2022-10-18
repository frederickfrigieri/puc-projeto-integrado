using Application._Configuration.Commands;
using Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.AssociarPedidoEstoque
{
    internal class AssociarPedidoEstoqueCommandHandler : ICommandHandler<AssociarPedidoEstoqueCommand>
    {
        private readonly IRepository _repository;

        public AssociarPedidoEstoqueCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public Task<Unit> Handle(
            AssociarPedidoEstoqueCommand request,
            CancellationToken cancellationToken)
        {
            //var pedidosPendentes = await _repository.ObterPedidosSemEstoque();

            //foreach (var pedidoPendente in pedidosPendentes)
            //{
            //    if (pedidoPendente.ArmazemId.HasValue)
            //    {
            //        var estoque = await _repository.ObterEstoqueDisponivel(
            //            pedidoPendente.ProdutoId,
            //            pedidoPendente.ArmazemId.Value,
            //            pedidoPendente.ChaveParceiro);

            //        estoque.AssociarItem(pedidoPendente);
            //    }
            //}

            return Unit.Task;
        }
    }
}
