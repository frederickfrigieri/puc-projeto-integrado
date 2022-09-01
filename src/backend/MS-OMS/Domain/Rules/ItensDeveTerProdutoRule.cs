using Domain._SeedWork;
using Domain.Dtos;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Rules
{
    internal class ItensDeveTerProdutoRule : IBusinessRule
    {
        private readonly List<ItemPedidoDto> _itens;
        private readonly List<ProdutoEntity> _produtos;

        public string Message => "Produto não encontrado ou não informado";

        public ItensDeveTerProdutoRule(List<ItemPedidoDto> itens, List<ProdutoEntity> produtos)
        {
            _itens = itens;
            _produtos = produtos;
        }

        public bool IsValid()
        {
            if (_produtos == null)
                return false;

            var qtdItens = _itens.Count();
            var qtdProduto = _produtos.Where(x => _itens.Select(x => x.ChaveProduto).ToArray().Contains(x.Chave)).Count();

            return _produtos != null && _produtos.Count() > 0 && qtdItens == qtdProduto;

        }
    }
}