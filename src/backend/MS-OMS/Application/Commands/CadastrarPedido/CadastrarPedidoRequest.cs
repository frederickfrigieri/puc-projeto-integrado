using System;

namespace Application.Commands.CadastrarPedido
{
    public class CadastrarPedidoRequest
    {
        public Guid ChaveParceiro { get; set; }
        public string NomeCompleto { get; set; }
        public decimal Valor { get; set; }

        public CadastrarItemPedidoRequest[] Itens { get; set; }

    }

    public class CadastrarItemPedidoRequest
    {
        public int Quantidade { get; set; }
        public string Sku { get; set; }
    }

}
