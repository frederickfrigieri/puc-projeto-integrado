using System;

namespace Domain.Dtos
{
    public struct ProdutoDto
    {
        public string Descricao { get; set; }
        public string Sku { get; set; }
        public Guid ChaveParceiro { get; set; }
    }
}
