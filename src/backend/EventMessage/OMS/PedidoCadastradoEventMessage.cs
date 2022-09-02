using EventMessage.SeedWork;
using System;
using System.Collections.Generic;

namespace EventMessage.OMS
{
    public class PedidoCadastradoEventMessage : DomainEventMessageBase
    {
        public PedidoCadastradoEventMessage(Guid chavePedido, List<ItemPedidoCadastradoEventMessage> itens)
        {
            ChavePedido = chavePedido;
            Itens = itens;
        }

        public Guid ChavePedido { get; set; }
        public List<ItemPedidoCadastradoEventMessage> Itens { get; set; }
    }

    public class ItemPedidoCadastradoEventMessage : DomainEventMessageBase
    {
        public Guid ChaveItem { get; set; }
        public Guid ChaveProduto { get; set; }
        public int Quantidade { get; set; }
    }
}
