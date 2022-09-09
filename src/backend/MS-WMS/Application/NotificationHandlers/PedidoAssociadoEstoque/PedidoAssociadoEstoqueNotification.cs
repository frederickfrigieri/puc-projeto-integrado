using Application._Configuration.DomainEvents;
using Domain.Events;
using System;
using System.Text.Json.Serialization;

namespace Application.NotificationHandlers.PedidoAssociadoEstoque
{
    public class PedidoAssociadoEstoqueNotification 
        : DomainNotificationBase<PedidoAssociadoEstoqueEvent>
    {

        public Guid ChavePedido { get; set; }
        public Guid ChaveEstoque { get; set; }

        public PedidoAssociadoEstoqueNotification(PedidoAssociadoEstoqueEvent domainEvent) : base(domainEvent)
        {
            ChavePedido = domainEvent.ChavePedido;
            ChaveEstoque = domainEvent.ChaveEstoque;
        }

        [JsonConstructor]
        public PedidoAssociadoEstoqueNotification() : base(null)
        {

        }
    }
}
