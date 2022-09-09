using Domain._SeedWork;
using System;

namespace Domain.Events
{
    public class PedidoAssociadoArmazemEvent : DomainEventBase
    {
        public PedidoAssociadoArmazemEvent(Guid chavePedido, Guid chaveArmazem)
        {
            ChavePedido = chavePedido;
            ChaveArmazem = chaveArmazem;
        }

        public Guid ChavePedido { get; set; }
        public Guid ChaveArmazem { get; set; }
    }
}
