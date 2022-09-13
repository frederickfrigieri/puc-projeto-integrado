using Application._Configuration.Commands;
using Domain;
using Domain.Dtos;
using Domain.Entities;
using MediatR;
using Serilog.RequestResponse.Extensions.Exceptions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.CadastrarPedido
{
    internal class CadastrarPedidoCommandHandler : ICommandHandler<CadastrarPedidoCommand>
    {
        private readonly IRepository _repository;

        public CadastrarPedidoCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CadastrarPedidoCommand request, CancellationToken cancellationToken)
        {
            var chavesProdutos = request.Itens
                .Select(x => x.ChaveProduto)
                .ToArray();

            var produtos = await _repository.ObterProdutoPorChaveAsync(chavesProdutos);

            foreach (var item in request.Itens)
            {
                var produto = produtos.SingleOrDefault(x => x.Chave == item.ChaveProduto);

                if (produto == null)
                    throw new DomainException("Produto não encontrado", 404);

                var dto = new ItemPedidoDto
                {
                    ChaveParceiro = request.ChaveParceiro,
                    ChavePedido = request.ChavePedido,
                    ProdutoId = produto.Id,
                    ChaveProduto = item.ChaveProduto,
                    Quantidade = item.Quantidade,
                    ChaveItem = item.ChaveItemPedido
                };

                var itemEntidade = PedidoItem.Criar(dto);

                await _repository.AdicionarAsync(itemEntidade);
            }

            return Unit.Value;
        }
    }
}
