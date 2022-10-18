using Application._Configuration.DomainEvents;
using Domain.Events;
using Newtonsoft.Json;
using System;

namespace Application.NotificationHandlers.PedidoImportado
{
    public class PedidoImportadoNotification : DomainNotificationBase<PedidoImportadoEvent>
    {
        public Guid ChavePedido { get; set; }

        public PedidoImportadoNotification(PedidoImportadoEvent domainEvent) : base(domainEvent)
        {
            ChavePedido = domainEvent.ChavePedido;
        }

        [JsonConstructor]
        public PedidoImportadoNotification() : base(null) { }

    }
}
