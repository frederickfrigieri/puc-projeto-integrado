using Application._Configuration.Commands;
using Domain;
using Domain.Dtos;
using Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.CadastrarProduto
{
    public class CadastrarProdutoCommandHandler
        : ICommandHandler<CadastrarProdutoCommand, object>
    {
        private readonly IRepository _repository;

        public CadastrarProdutoCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> Handle(
            CadastrarProdutoCommand request,
            CancellationToken cancellationToken)
        {
            var produto = await _repository
                .ObterProdutosPorPorParceirtoESku(request.ChaveParceiro, request.Sku);

            if (produto == null)
            {
                var dto = new ProdutoDto
                {
                    Descricao = request.Descricao,
                    Sku = request.Sku,
                    ChaveParceiro = request.ChaveParceiro
                };

                produto = new Produto(request.Descricao, request.Sku, request.ChaveParceiro);

                await _repository.AdicionarAsync(produto);
            }

            return new
            {
                produto.Chave,
                produto.Sku,
                produto.Descricao,
                DateTime.Now
            };
        }
    }
}
