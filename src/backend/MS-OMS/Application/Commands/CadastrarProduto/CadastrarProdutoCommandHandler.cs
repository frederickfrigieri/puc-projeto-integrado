using Application._Configuration.Commands;
using Domain;
using Domain.Dtos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.CadastrarProduto
{
    public class CadastrarProdutoCommandHandler
        : ICommandHandler<CadastrarProdutoCommand, Guid>
    {
        private readonly IRepository _repository;

        public CadastrarProdutoCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(
            CadastrarProdutoCommand request,
            CancellationToken cancellationToken)
        {
            var parceiro = await _repository.ObterParceiroAsync(request.ChaveParceiro,
                new string[]
                {
                    "Produtos"
                });

            var dto = new ProdutoDto
            {
                Descricao = request.Descricao,
                Sku = request.Sku,
                ParceiroId = parceiro.Id
            };

            var chaveProduto = parceiro.CriarProduto(dto);

            return chaveProduto;
        }
    }
}
