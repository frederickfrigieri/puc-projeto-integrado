using Domain._SeedWork;
using System;

namespace Domain.Events
{
    public class PedidoCadastradoEvent : DomainEventBase
    {
        public Guid ChavePedido { get; set; }

        public PedidoCadastradoEvent(Guid chavePedido)
        {
            ChavePedido = chavePedido;
        }
    }
}
