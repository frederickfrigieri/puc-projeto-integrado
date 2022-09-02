using System;

namespace Domain.Dtos
{
    public class ProdutoDto
    {
        public string Descricao { get; set; }
        public string Sku { get; set; }
        public Guid ChaveParceiro { get; set; }
    }
}
