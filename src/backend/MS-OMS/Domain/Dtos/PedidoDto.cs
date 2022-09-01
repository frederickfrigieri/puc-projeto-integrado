using System;
using System.Collections.Generic;

namespace Domain.Dtos
{
    public class PedidoDto
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public Guid ChaveParceiro { get; set; }

        public List<ItemPedidoDto> Itens { get; set; }
    }
}
