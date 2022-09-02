using Application._Configuration.DomainEvents;
using Domain.Events;
using System;
using System.Text.Json.Serialization;

namespace Application.NotificationHandlers.PedidoCadastrado
{
    public class PedidoCadastradoNotification : DomainNotificationBase<PedidoCadastradoEvent>
    {
        public Guid ChavePedido { get; set; }

        public PedidoCadastradoNotification(PedidoCadastradoEvent domainEvent) : base(domainEvent)
        {
            ChavePedido = domainEvent.ChavePedido;
        }

        [JsonConstructor]
        public PedidoCadastradoNotification() : base(null)
        {
        }
    }
}
