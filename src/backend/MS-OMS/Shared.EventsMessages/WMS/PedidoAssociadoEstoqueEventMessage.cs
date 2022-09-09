using Shared.EventsMessages.SeedWork;
using System;

namespace Shared.EventsMessages.WMS
{
    public class PedidoAssociadoEstoqueEventMessage : DomainEventMessageBase
    {
        public Guid ChavePedido { get; set; }
        public Guid ChaveEstoque { get; set; }
    }
}
