using Application._Configuration.Commands;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Domain;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
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
            var itens = (await _repository.ObterItensPorPedido(request.ChavePedido)).ToList();

            if (itens.Any(x => x.ArmazemId != null))
                return Unit.Value;

            var armazens = await _repository.ObterArmazemMenorQuantidadePedido();
            List<Armazem> armazemSelecionado = null;

            foreach (var armazem in armazens)
            {
                armazemSelecionado = new List<Armazem>();

                itens.ForEach(item =>
                {
                    var total = armazem.Estoques
                        .Where(x => x.ProdutoId == item.ProdutoId && x.PedidoItem == null)
                        .Count();

                    if (total >= item.Quantidade) armazemSelecionado.Add(armazem);
                });

                if (armazemSelecionado.Count() == itens.Count())
                {
                    itens.ToList().ForEach(item =>
                    {
                        item.AssociarArmazem(armazemSelecionado.FirstOrDefault());
                    });

                    return Unit.Value;
                }
            }

            return Unit.Value;
        }
    }
}
