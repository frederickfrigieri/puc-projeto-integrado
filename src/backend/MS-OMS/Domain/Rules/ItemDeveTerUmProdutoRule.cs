using Domain._SeedWork;

namespace Domain.Rules
{
    internal class ItemDeveTerUmProdutoRule : IBusinessRule
    {
        public string Message => "Produto inválido";

        private readonly int? _produtoId;

        public ItemDeveTerUmProdutoRule(int? produtoId)
        {
            _produtoId = produtoId;
        }

        public bool IsValid()
        {
            return _produtoId.HasValue && _produtoId.Value != 0;

        }
    }
}