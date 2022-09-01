using Domain._SeedWork;
using Domain.Dtos;
using System.Collections.Generic;

namespace Domain.Rules
{
    internal class PedidoDeveTerItemRule : IBusinessRule
    {
        private readonly List<ItemPedidoDto> _itens;

        public string Message => "Pedido deve ter ao menos um item";

        public PedidoDeveTerItemRule(List<ItemPedidoDto> itens)
        {
            _itens = itens;
        }

        public bool IsValid()
        {
            return _itens != null
                && _itens.Count > 0;
        }
    }
}