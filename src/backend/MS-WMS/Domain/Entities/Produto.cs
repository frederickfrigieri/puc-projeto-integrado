using Domain._SeedWork;
using Domain.Events;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Produto : Entity, IAggregateRoot
    {
        public string Descricao { get; private set; }
        public string Sku { get; private set; }

        public Guid ChaveParceiro { get; private set; }

        public List<ItemPedido> ItensPedidos { get; private set; }

        private Produto()
        {
        }

        public Produto(string descricao, string sku, Guid chaveParceiro)
        {
            Descricao = descricao;
            Sku = sku;
            ChaveParceiro = chaveParceiro;

            AddDomainEvent(new ProdutoCadastradoEvent(Chave, Descricao, ChaveParceiro, Sku));
        }

    }
}
