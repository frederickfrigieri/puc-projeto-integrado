using EventMessage.SeedWork;
using System;

namespace EventMessage.WMS
{
    public class ProdutoCadastradoEventMessage : DomainEventMessageBase
    {
        public Guid ChaveProduto { get; set; }
        public string Sku { get; set; }
        public string Descricao { get; set; }
        public Guid ChaveParceiro { get; set; }
    }
}
