using Domain._SeedWork;
using System;

namespace Domain.Events
{
    public class PedidoImportadoEvent : DomainEventBase
    {
        public Guid ChavePedido { get; set; }

        public PedidoImportadoEvent(Guid chaveItemPedido)
        {
            ChavePedido = chaveItemPedido;
        }
    }
}
