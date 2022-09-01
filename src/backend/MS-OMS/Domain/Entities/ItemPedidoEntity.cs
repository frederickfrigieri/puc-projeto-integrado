using Domain._SeedWork;
using Domain.Dtos;
using Domain.Rules;

namespace Domain.Entities
{
    public class ItemPedidoEntity : Entity, IAggregateRoot
    {
        public int Quantidade { get; private set; }

        public int ProdutoId { get; private set; }
        public ProdutoEntity Produto { get; private set; }

        public int PedidoId { get; set; }
        public PedidoEntity Pedido { get; set; }

        private ItemPedidoEntity()
        {
        }

        public static ItemPedidoEntity Criar(ItemPedidoDto dto)
        {
            CheckRule(new ItemDeveTerUmProdutoRule(dto.ProdutoId));
            CheckRule(new ItemDeveTerQuantidadeSuperiorAZero(dto));

            return new ItemPedidoEntity()
            {
                Quantidade = dto.Quantidade,
                ProdutoId = dto.ProdutoId.Value
            };
        }
    }

}
