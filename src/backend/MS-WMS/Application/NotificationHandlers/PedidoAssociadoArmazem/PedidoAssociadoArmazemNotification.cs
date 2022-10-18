using Application._Configuration.DomainEvents;
using Domain.Events;
using Newtonsoft.Json;
using System;

namespace Application.NotificationHandlers.PedidoAssociadoArmazem
{
    public class PedidoAssociadoArmazemNotification : DomainNotificationBase<PedidoAssociadoArmazemEvent>
    {
        public Guid ChavePedido { get; set; }
        public Guid ChaveArmazem { get; set; }

        public PedidoAssociadoArmazemNotification(PedidoAssociadoArmazemEvent domainEvent) : base(domainEvent)
        {
            ChavePedido = domainEvent.ChavePedido;
            ChaveArmazem = domainEvent.ChaveArmazem;
        }

        [JsonConstructor]
        public PedidoAssociadoArmazemNotification() : base(null)
        {

        }
    }
}
