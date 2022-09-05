using Domain._SeedWork;
using Domain.Dtos;
using System;

namespace Domain.Entities
{
    public class ItemPedido : Entity, IAggregateRoot
    {
        public int Quantidade { get; private set; }

        internal ItemPedido(int quantidade, Produto produto, Guid chavePedido, Guid chaveParceiro)
        {
            Quantidade = quantidade;
            Produto = produto;
            ChavePedido = chavePedido;
            ChaveParceiro = chaveParceiro;
        }

        public int ProdutoId { get; private set; }
        public Produto Produto { get; private set; }

        public Guid ChavePedido { get; private set; }
        public Guid ChaveParceiro { get; private set; }

        public int? ArmazemId { get; private set; }
        public Armazem Armazem { get; private set; }


        private ItemPedido()
        {
        }

        public static ItemPedido Criar(ItemPedidoDto dto)
        {
            return new ItemPedido()
            {
                Quantidade = dto.Quantidade,
                ProdutoId = dto.ProdutoId.Value,
                ChaveParceiro = dto.ChaveParceiro,
                ChavePedido = dto.ChavePedido
            };
        }

        public void AssociarArmazem(Armazem armazem)
        {
            Armazem = armazem;
        }
    }

}
