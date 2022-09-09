using Domain._SeedWork;
using System;

namespace Domain.Events
{
    public class PedidoAssociadoEstoqueEvent : DomainEventBase
    {
        public PedidoAssociadoEstoqueEvent(Guid chavePedido, Guid chaveEstoque)
        {
            ChavePedido = chavePedido;
            ChaveEstoque = chaveEstoque;
        }

        public Guid ChavePedido { get; set; }
        public Guid ChaveEstoque { get; set; }
    }
}