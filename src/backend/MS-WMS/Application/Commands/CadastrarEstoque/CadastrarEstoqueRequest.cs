using System;

namespace Application.Commands.CadastrarEstoque
{
    public class CadastrarEstoqueRequest
    {
        public Guid ChaveParceiro { get; set; }
        public Guid ChaveArmazem { get; set; }
        public Guid ChaveProduto { get; set; }
        public short Quantidade { get; set; }
    }
}
