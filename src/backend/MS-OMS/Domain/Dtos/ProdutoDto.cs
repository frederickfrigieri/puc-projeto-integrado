using System;

namespace Domain.Dtos
{
    public class ProdutoDto
    {
        public string Descricao { get; set; }
        public string Sku { get; set; }
        public int ParceiroId { get; set; }
        public Guid ChaveProduto { get; set; }
    }
}
