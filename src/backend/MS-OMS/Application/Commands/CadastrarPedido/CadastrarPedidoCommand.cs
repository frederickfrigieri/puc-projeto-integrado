using Application._Configuration.Commands;
using System;

namespace Application.Commands.CadastrarPedido
{
    public class CadastrarPedidoCommand : CommandBase<Guid>
    {
        public Guid ChaveParceiro { get; set; }
        public string NomeCompleto { get; set; }
        public decimal Valor { get; set; }

        public CadastrarItemPedidoCommand[] Itens { get; set; }
    }

    public class CadastrarItemPedidoCommand
    {
        public int Quantidade { get; set; }
        public Guid ChaveProduto { get; set; }
    }
}
