using Application._Configuration.Commands;
using System;
using System.Collections.Generic;

namespace Application.Commands.CadastrarPedido
{
    public class CadastrarItemPedidoCommand : CommandBase
    {
        public Guid ChaveProduto { get; set; }
        public Guid ChaveItemPedido { get; set; }
        public int Quantidade { get; set; }
    }

    public class CadastrarPedidoCommand : CommandBase
    {
        public CadastrarPedidoCommand(Guid chaveParceiro, Guid chavePedido)
        {
            ChaveParceiro = chaveParceiro;
            ChavePedido = chavePedido;

            Itens = new List<CadastrarItemPedidoCommand>();
        }

        public Guid ChaveParceiro { get; set; }
        public Guid ChavePedido { get; set; }
        public List<CadastrarItemPedidoCommand> Itens { get; set; }
    }
}
