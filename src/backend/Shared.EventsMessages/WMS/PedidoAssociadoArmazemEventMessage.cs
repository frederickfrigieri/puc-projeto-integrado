using Shared.EventsMessages.SeedWork;
using System;

namespace Shared.EventsMessages.WMS
{
    public class PedidoAssociadoArmazemEventMessage : DomainEventMessageBase
    {
        public Guid ChavePedido { get; set; }
        public Guid ChaveArmazem { get; set; }
    }
}
