using Application._Configuration.Commands;
using Domain;
using Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.CadastrarEstoque
{
    public class CadastrarEstoqueCommandHandler : ICommandHandler<CadastrarEstoqueCommand, Estoque[]>
    {
        private IRepository _repository;

        public CadastrarEstoqueCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Estoque[]> Handle(CadastrarEstoqueCommand request, CancellationToken cancellationToken)
        {
            var armazem = await _repository
                .ObterArmazemAsync(request.ChaveArmazem);
            var produto = await _repository
                .ObterProdutoPorChaveAsync(new Guid[] { request.ChaveProduto });

            var estoque = armazem.CadastrarEstoque(
                request.ChaveParceiro,
                produto[0],
                request.Quantidade);

            return estoque;

        }
    }
}
