using System;

namespace Domain.Dtos
{
    public struct ItemPedidoDto
    {
        public short Quantidade { get; set; }
        public Guid ChaveProduto { get; set; }
    }
}
