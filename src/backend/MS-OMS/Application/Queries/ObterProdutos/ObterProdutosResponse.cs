using System;

namespace Application.ObterProdutosPorParceiro
{
    public class ObterProdutosResponse
    {
        public Guid Chave { get; set; }
        public string DataCadastro { get; set; }
        public string Descricao { get; set; }
        public string Sku { get; set; }
        public string RazaoSocial { get; set; }
    }
}
