using Domain._SeedWork;
using System;

namespace Domain.Entities
{
    public class Estoque : Entity, IAggregateRoot
    {
        internal Estoque(Guid chaveParceiro, Produto produto)
        {
            ChaveParceiro = chaveParceiro;
            //Armazem = armazem;
            Produto = produto;
        }

        private Estoque() { }

        public Guid ChaveParceiro { get; private set; }
        public int ArmazemId { get; private set; }
        public Armazem Armazem { get; private set; }

        public int ProdutoId { get; private set; }
        public Produto Produto { get; private set; }
        public int? ItemPedidoId { get; private set; }
        public ItemPedido ItemPedido { get; private set; }

        public int? PosicaoId { get; private set; }
        public Posicao Posicao { get; private set; }

        public void AssociarItem(ItemPedido item)
        {
            ItemPedido = item;
        }
    }
}
