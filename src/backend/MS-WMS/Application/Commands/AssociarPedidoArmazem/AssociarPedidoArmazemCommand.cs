using Application._Configuration.Commands;
using System;

namespace Application.Commands.AssociarPedidoArmazem
{
    public class AssociarPedidoArmazemCommand : CommandBase
    {
        public Guid ChavePedido { get; set; }

        public AssociarPedidoArmazemCommand(Guid chavePedido)
        {
            ChavePedido = chavePedido;
        }
    }
}
