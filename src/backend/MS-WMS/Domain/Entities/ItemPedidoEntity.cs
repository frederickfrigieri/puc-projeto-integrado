using Domain._SeedWork;
using Domain.Dtos;
using System;

namespace Domain.Entities
{
    public class ItemPedidoEntity : Entity, IAggregateRoot
    {
        public int Quantidade { get; private set; }

        internal ItemPedidoEntity(int quantidade, ProdutoEntity produto, Guid chavePedido, Guid chaveParceiro)
        {
            Quantidade = quantidade;
            Produto = produto;
            ChavePedido = chavePedido;
            ChaveParceiro = chaveParceiro;
        }

        public int ProdutoId { get; private set; }
        public ProdutoEntity Produto { get; private set; }

        public Guid ChavePedido { get; private set; }
        public Guid ChaveParceiro { get; private set; }

        public int ArmazemId { get; private set; }
        public Armazem Armazem { get; private set; }


        private ItemPedidoEntity()
        {
        }

        public static ItemPedidoEntity Criar(ItemPedidoDto dto)
        {
            return new ItemPedidoEntity()
            {
                Quantidade = dto.Quantidade,
                ProdutoId = dto.ProdutoId.Value
            };
        }

        public void AssociarArmazem(Armazem armazem)
        {
            Armazem = armazem;
        }
    }

}
