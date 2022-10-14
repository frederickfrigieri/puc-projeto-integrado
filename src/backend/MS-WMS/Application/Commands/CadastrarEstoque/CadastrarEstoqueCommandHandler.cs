using Application._Configuration.Commands;
using Domain;
using Domain.Entities;
using MediatR;
using Serilog.RequestResponse.Extensions.Exceptions;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.CadastrarEstoque
{
    public class CadastrarEstoqueCommandHandler : ICommandHandler<CadastrarEstoqueCommand, Unit>
    {
        private IRepository _repository;
        private readonly UsuarioAutenticado _usuarioAutenticado;


        public CadastrarEstoqueCommandHandler(
            IRepository repository,
            UsuarioAutenticado usuarioAutenticado)
        {
            _repository = repository;
            _usuarioAutenticado = usuarioAutenticado;
        }

        public async Task<Unit> Handle(CadastrarEstoqueCommand request, CancellationToken cancellationToken)
        {
            if (_usuarioAutenticado.Chave != request.ChaveParceiro)
                throw new DomainException("Chave do Parceiro informada diferente da chave da sessão logada.");

            if (_usuarioAutenticado.Perfil != Domain.Enums.PerfilUsuario.Parceiro)
                throw new DomainException("Somente o Perfil do Parceiro pode dar entrada no seu Estoque.");

            var chaveParceiro = _usuarioAutenticado.Chave;

            var armazem = await _repository
                .ObterArmazemAsync(request.ChaveArmazem,
                new string[] {
                    "Estoques"
                });

            var produto = await _repository
                .ObterProdutoPorChaveAsync(new Guid[] { request.ChaveProduto });

            armazem.CadastrarEstoque(chaveParceiro, produto.First(), request.Quantidade);

            return Unit.Value;
        }
    }
}
