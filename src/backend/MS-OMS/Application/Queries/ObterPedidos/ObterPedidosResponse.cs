using System;

namespace Application.ObterPedidos
{
    public class ObterPedidosResponse
    {
        public Guid Chave { get; set; }
        public string DataPedido { get; set; }
        public string Cliente { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public string Produto { get; set; }
        public string StatusPedido { get; set; }
        public string Armazem { get; set; }
    }
}
