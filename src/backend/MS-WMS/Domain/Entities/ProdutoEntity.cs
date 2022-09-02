using Domain._SeedWork;
using Domain.Dtos;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class ProdutoEntity : Entity, IAggregateRoot
    {
        public string Descricao { get; private set; }
        public string Sku { get; private set; }

        public Guid ChaveParceiro { get; private set; }

        public List<ItemPedidoEntity> ItensPedidos { get; private set; }

        private ProdutoEntity()
        {
        }

        public static ProdutoEntity CriarProduto(ProdutoDto dto)
        {
            var entity = new ProdutoEntity()
            {
                Descricao = dto.Descricao,
                Sku = dto.Sku,
                ChaveParceiro = dto.ChaveParceiro
            };

            return entity;
        }
    }
}
