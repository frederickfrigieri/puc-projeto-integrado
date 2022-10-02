using Shared.EventsMessages.SeedWork;
using System;

namespace Shared.EventsMessages.WMS
{
    public class ProdutoCadastradoEventMessage : DomainEventMessageBase
    {
        public Guid ChaveProduto { get; set; }
        public string Sku { get; set; }
        public string Descricao { get; set; }
        public Guid ChaveParceiro { get; set; }
    }
}
