using Domain._SeedWork;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Rules
{
    internal class ParceiroDeveTerUmOuMaisProdutoRule : IBusinessRule
    {
        private readonly List<ProdutoEntity> _produtos;

        public string Message => "Nenhum produto encontrado";

        public ParceiroDeveTerUmOuMaisProdutoRule(List<ProdutoEntity> produtos)
        {
            _produtos = produtos;
        }

        public bool IsValid()
        {
            return _produtos != null && _produtos.Count() > 0;
        }
    }
}