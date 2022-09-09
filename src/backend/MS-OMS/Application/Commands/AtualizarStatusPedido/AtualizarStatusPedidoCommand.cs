using Application._Configuration.Commands;
using Domain.Entities.Enums;
using System;

namespace Application.Commands.AtualizarStatusPedido
{
    public class AtualizarStatusPedidoCommand : CommandBase
    {
        public Guid ChavePedido { get; set; }
        public StatusPedidoEnum StatusPedido { get; set; }
    }
}
