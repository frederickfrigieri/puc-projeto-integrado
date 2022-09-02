using System;

namespace Domain.Dtos
{
    public class ItemPedidoDto
    {
        public int Quantidade { get; set; }
        public int? ProdutoId { get; set; }
        public Guid ChaveProduto { get; set; }
        public Guid ChaveParceiro { get; set; }
        public Guid ChavePedido { get; set; }
    }
}
