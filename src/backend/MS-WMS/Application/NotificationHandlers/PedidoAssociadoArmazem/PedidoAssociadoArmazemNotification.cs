using Application._Configuration.DomainEvents;
using Domain.Events;
using System;
using System.Text.Json.Serialization;

namespace Application.NotificationHandlers.PedidoAssociadoArmazem
{
    public class PedidoAssociadoArmazemNotification : DomainNotificationBase<PedidoAssociadoArmazemEvent>
    {
        public PedidoAssociadoArmazemNotification(PedidoAssociadoArmazemEvent domainEvent)
            : base(domainEvent)
        {
            ChavePedido = domainEvent.ChavePedido;
            ChaveArmazem = domainEvent.ChaveArmazem;
        }

        public Guid ChavePedido { get; set; }
        public Guid ChaveArmazem { get; set; }

        [JsonConstructor]
        public PedidoAssociadoArmazemNotification() : base(null)
        {

        }
    }
}
