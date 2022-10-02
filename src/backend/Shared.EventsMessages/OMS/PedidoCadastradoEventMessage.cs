using Shared.EventsMessages.SeedWork;
using System;
using System.Collections.Generic;

namespace Shared.EventsMessages.OMS
{
    public class PedidoCadastradoEventMessage : DomainEventMessageBase
    {
        public PedidoCadastradoEventMessage(
            Guid chavePedido,
            List<ItemPedidoCadastradoEventMessage> itens,
            Guid chaveParceiro)
        {
            ChavePedido = chavePedido;
            Itens = itens;
            ChaveParceiro = chaveParceiro;
        }

        public Guid ChavePedido { get; set; }
        public Guid ChaveParceiro { get; set; }

        public List<ItemPedidoCadastradoEventMessage> Itens { get; set; }
    }

    public class ItemPedidoCadastradoEventMessage : DomainEventMessageBase
    {
        public Guid ChaveItem { get; set; }
        public Guid ChaveProduto { get; set; }
        public int Quantidade { get; set; }
    }
}
