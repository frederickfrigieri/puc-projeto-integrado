using Application._Configuration.Commands;
using Domain.Entities;
using MediatR;
using System;

namespace Application.Commands.CadastrarEstoque
{
    public class CadastrarEstoqueCommand : CommandBase<Unit>
    {
        public Guid ChaveParceiro { get; set; }
        public Guid ChaveProduto { get; set; }
        public Guid ChaveArmazem { get; set; }
        public short Quantidade { get; set; }
    }
}
