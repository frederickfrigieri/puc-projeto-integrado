using Domain._SeedWork;
using System;

namespace Domain.Entities
{
    public class Estoque : Entity, IAggregateRoot
    {
        internal Estoque(Guid chaveParceiro, Armazem armazem, ProdutoEntity produto)
        {
            ChaveParceiro = chaveParceiro;
            Armazem = armazem;
            Produto = produto;
        }

        private Estoque()
        {

        }

        public Guid ChaveParceiro { get; private set; }

        public int ItemPedidoId { get; private set; }
        public ItemPedidoEntity ItemPedido { get; private set; }

        public int PosicaoId { get; private set; }
        public Posicao Posicao { get; private set; }

        public int ArmazemId { get; private set; }
        public Armazem Armazem { get; private set; }

        public int ProdutoId { get; private set; }
        public ProdutoEntity Produto { get; private set; }

        public void AssociarItem(ItemPedidoEntity item)
        {
            ItemPedido = item;
        }
    }
}
