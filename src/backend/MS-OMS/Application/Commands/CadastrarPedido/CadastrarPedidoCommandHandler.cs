using Application._Configuration.Commands;
using Domain;
using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.CadastrarPedido
{
    public class CadastrarPedidoCommandHandler : ICommandHandler<CadastrarPedidoCommand, Guid>
    {
        private readonly IRepository _repository;

        public CadastrarPedidoCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CadastrarPedidoCommand request, CancellationToken cancellationToken)
        {
            var pedidoDto = new PedidoDto
            {
                Nome = request.NomeCompleto,
                Valor = request.Valor,
                Itens = new List<ItemPedidoDto>(),
                ChaveParceiro = request.ChaveParceiro
            };

            var parceiro = await _repository
                .ObterParceiroAsync(request.ChaveParceiro, new string[] { "Produtos" });


            foreach (var item in request.Itens)
            {
                var produto = parceiro.Produtos.SingleOrDefault(x => x.Sku == item.Sku);
                var itemDto = new ItemPedidoDto
                {
                    ChaveProduto = produto.Chave,
                    Quantidade = item.Quantidade
                };

                pedidoDto.Itens.Add(itemDto);
            }

            var chavePedido = parceiro.CriarPedido(pedidoDto);

            return chavePedido;
        }
    }
}
