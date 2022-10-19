using Application._Configuration.Commands;
using MediatR;
using System;

namespace Application.Commands.AssociarPedidoArmazem
{
    public class AssociarPedidoArmazemCommand : CommandBase<Unit>
    {
        public Guid ChavePedido { get; set; }
        public Guid ChaveArmazem { get; set; }

        public AssociarPedidoArmazemCommand(Guid chavePedido, Guid chaveArmazem)
        {
            ChavePedido = chavePedido;
            ChaveArmazem = chaveArmazem;
        }
    }
}
