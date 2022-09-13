using Domain._SeedWork;
using Domain.Dtos;
using Domain.Events;
using System;

namespace Domain.Entities
{
    public class PedidoItem : Entity, IAggregateRoot
    {
        public int Quantidade { get; private set; }

        internal PedidoItem(int quantidade, Produto produto, Guid chavePedido, Guid chaveParceiro, Guid chaveItem)
        {
            Quantidade = quantidade;
            Produto = produto;
            ChavePedido = chavePedido;
            ChaveParceiro = chaveParceiro;
            Chave = chaveItem;
        }

        private PedidoItem(){}

        public int ProdutoId { get; private set; }
        public Produto Produto { get; private set; }

        public Guid ChavePedido { get; private set; }
        public Guid ChaveParceiro { get; private set; }

        public int? ArmazemId { get; private set; }
        public Armazem Armazem { get; private set; }

        public static PedidoItem Criar(ItemPedidoDto dto)
        {
            //Todo depois usar o constructor
            return new PedidoItem()
            {
                Quantidade = dto.Quantidade,
                ProdutoId = dto.ProdutoId.Value,
                ChaveParceiro = dto.ChaveParceiro,
                ChavePedido = dto.ChavePedido,
                Chave = dto.ChaveItem
            };
        }

        public void AssociarArmazem(Armazem armazem)
        {
            Armazem = armazem;

            AddDomainEvent(new PedidoAssociadoArmazemEvent(ChavePedido, armazem.Chave));
        }
    }

}
