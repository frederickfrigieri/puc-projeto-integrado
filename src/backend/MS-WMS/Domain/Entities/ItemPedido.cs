using Domain._SeedWork;
using Domain.Dtos;
using Domain.Events;
using System;

namespace Domain.Entities
{
    public class PedidoItem : Entity, IAggregateRoot
    {
        public int Quantidade { get; private set; }

        internal PedidoItem(int quantidade, int produtoId, Guid chavePedido, Guid chaveParceiro, Guid chaveItem)
        {
            Quantidade = quantidade;
            ProdutoId = produtoId;
            ChavePedido = chavePedido;
            ChaveParceiro = chaveParceiro;
            Chave = chaveItem;

            AddDomainEvent(new PedidoImportadoEvent(chavePedido));
        }

        private PedidoItem() { }

        public int ProdutoId { get; private set; }
        public Produto Produto { get; private set; }

        public Guid ChavePedido { get; private set; }
        public Guid ChaveParceiro { get; private set; }

        public int? ArmazemId { get; private set; }
        public Armazem Armazem { get; private set; }

        public static PedidoItem Criar(ItemPedidoDto dto)
        {

            return new PedidoItem(
                dto.Quantidade,
                dto.ProdutoId.Value,
                dto.ChavePedido,
                dto.ChaveParceiro,
                dto.ChaveItem);
        }

        public void AssociarArmazem(Armazem armazem)
        {
            Armazem = armazem;

            AddDomainEvent(new PedidoAssociadoArmazemEvent(ChavePedido, armazem.Chave));
        }
    }

}
