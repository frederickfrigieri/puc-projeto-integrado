using Domain._SeedWork;
using Domain.Events;
using System;

namespace Domain.Entities
{
    public class Estoque : Entity, IAggregateRoot
    {
        internal Estoque(Guid chaveParceiro, Produto produto)
        {
            ChaveParceiro = chaveParceiro;
            Produto = produto;
        }

        private Estoque() { }

        public Guid ChaveParceiro { get; private set; }
        public int ArmazemId { get; private set; }
        public Armazem Armazem { get; private set; }

        public int ProdutoId { get; private set; }
        public Produto Produto { get; private set; }
        public int? PedidoItemId { get; private set; }
        public PedidoItem PedidoItem { get; private set; }

        public int? PosicaoId { get; private set; }
        public Posicao Posicao { get; private set; }

        public void AssociarItem(PedidoItem item)
        {
            PedidoItem = item;

            AddDomainEvent(new PedidoAssociadoEstoqueEvent(PedidoItem.Chave, Chave));
        }
    }
}
