using Domain._SeedWork;
using Domain.Dtos;
using Domain.Rules;
using System;

namespace Domain.Entities
{
    public class ItemPedidoEntity : Entity, IAggregateRoot
    {
        public short Quantidade { get; private set; }
        public Guid ChaveProduto { get; private set; }
        public ProdutoEntity Produto { get; private set; }

        private ItemPedidoEntity()
        {
        }

        public static ItemPedidoEntity Criar(ItemPedidoDto dto)
        {
            CheckRule(new ItemDeveTerUmProdutoRule(dto.ChaveProduto));
            CheckRule(new ItemDeveTerQuantidadeSuperiorAZero(dto));

            return new ItemPedidoEntity()
            {
                Quantidade = dto.Quantidade,
                ChaveProduto = dto.ChaveProduto
            };
        }
    }

}
