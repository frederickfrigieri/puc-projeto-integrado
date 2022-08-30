using Domain._SeedWork;
using System;

namespace Domain.Events
{
    public class PedidoCriadoEvent : DomainEventBase
    {
        public Guid ChavePedido { get; set; }

        public PedidoCriadoEvent(Guid chavePedido)
        {
            ChavePedido = chavePedido;
        }
    }
}
