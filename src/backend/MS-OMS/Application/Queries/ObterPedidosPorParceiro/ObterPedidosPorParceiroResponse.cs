using System;

namespace Application.ObterPedidosPorParceiro
{
    public class ObterPedidosPorParceiroResponse
    {
        public Guid Chave { get; set; }
        public string DataCadastro { get; set; }
        public string NomeCompleto { get; set; }
        public decimal Valor { get; set; }

        public ObterPedidoPorParceiroItemResponse[] Itens { get; set; }
    }

    public class ObterPedidoPorParceiroItemResponse
    {
        public Guid Chave { get; set; }
        public string DataCadastro { get; set; }
        public int Quantidade { get; set; }
        public string Produto { get; set; }
    }
}
