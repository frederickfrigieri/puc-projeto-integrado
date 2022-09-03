using Domain._SeedWork;
using System;

namespace Domain.Events
{
    public class ProdutoCadastradoEvent : DomainEventBase
    {
        public Guid ChaveProduto { get; set; }
        public string Descricao { get; set; }
        public Guid ChaveParceiro { get; set; }
        public string Sku { get; set; }

        public ProdutoCadastradoEvent(Guid chaveProduto, string descricao, Guid chaveParceiro, string sku)
        {
            ChaveProduto = chaveProduto;
            Descricao = descricao;
            ChaveParceiro = chaveParceiro;
            Sku = sku;
        }
    }
}
