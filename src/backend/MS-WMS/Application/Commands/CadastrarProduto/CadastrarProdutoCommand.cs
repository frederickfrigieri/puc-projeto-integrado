using Application._Configuration.Commands;
using System;

namespace Application.Commands.CadastrarProduto
{
    public class CadastrarProdutoCommand : CommandBase<Guid>
    {
        public string Descricao { get; set; }
        public string Sku { get; set; }
        public Guid ChaveParceiro { get; set; }
    }
}
