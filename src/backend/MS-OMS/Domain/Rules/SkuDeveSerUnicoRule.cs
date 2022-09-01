using Domain._SeedWork;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Rules
{
    public class SkuDeveSerUnicoRule : IBusinessRule
    {
        private readonly string _sku;
        private readonly List<ProdutoEntity> _produtos;

        public SkuDeveSerUnicoRule(string sku, List<ProdutoEntity> produtos)
        {
            _sku = sku;
            _produtos = produtos;
        }

        public string Message => "Sku já existe";

        public bool IsValid()
        {
            return _produtos == null
                || _produtos.Count == 0
                || _produtos.Any(x => x.Sku == _sku) == false;
        }
    }
}
