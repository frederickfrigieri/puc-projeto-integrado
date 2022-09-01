using System;

namespace Application.Commands.CadastrarProduto
{
    public class CadastrarProdutoRequest
    {
        public string Descricao { get; set; }
        public string Sku { get; set; }
        public Guid ChaveParceiro { get; set; }
    }
}
