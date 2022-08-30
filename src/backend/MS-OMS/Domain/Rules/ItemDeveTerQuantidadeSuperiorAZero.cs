using Domain._SeedWork;
using Domain.Dtos;

namespace Domain.Rules
{
    internal class ItemDeveTerQuantidadeSuperiorAZero : IBusinessRule
    {
        private readonly ItemPedidoDto _dto;

        public string Message => "Quantidade deve ser maior que 0";

        public ItemDeveTerQuantidadeSuperiorAZero(ItemPedidoDto dto)
        {
            _dto = dto;
        }

        public bool IsValid()
        {
            return _dto.Quantidade > 0;
        }
    }
}