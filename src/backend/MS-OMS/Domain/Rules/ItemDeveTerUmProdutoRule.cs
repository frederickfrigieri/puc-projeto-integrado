using Domain._SeedWork;
using System;

namespace Domain.Rules
{
    internal class ItemDeveTerUmProdutoRule : IBusinessRule
    {
        public string Message => "Produto inválido";

        private readonly Guid _chaveProduto;

        public ItemDeveTerUmProdutoRule(Guid chaveProduto)
        {
            _chaveProduto = chaveProduto;
        }

        public bool IsValid()
        {
            return _chaveProduto != null
                && _chaveProduto != Guid.Empty;
        }
    }
}