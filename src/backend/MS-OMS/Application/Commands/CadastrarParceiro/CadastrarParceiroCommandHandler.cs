using Application._Configuration.Commands;
using Application.Services.Contracts;
using Domain;
using Domain.Dtos;
using Domain.Entities;
using MediatR;
using Serilog.RequestResponse.Extensions.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.CadastrarParceiro
{
    public class CadastrarParceiroCommandHandler : ICommandHandler<CadastrarParceiroCommand>
    {
        private readonly IRepository _repository;
        private readonly IAutenticacao _autenticacao;


        public CadastrarParceiroCommandHandler(
            IRepository repository,
            IAutenticacao autenticacao)
        {
            _repository = repository;
            _autenticacao = autenticacao;
        }

        public async Task<Unit> Handle(CadastrarParceiroCommand request, CancellationToken cancellationToken)
        {
            var dto = new ParceiroCreateDto
            {
                Cnpj = request.Cnpj,
                RazaoSocial = request.RazaoSocial,
                ChaveBling = Guid.NewGuid().ToString(),
                Email = request.Email,
                Nome = request.Nome,
                Senha = request.Senha
            };

            var loginUtilizado = await _autenticacao.ExisteLogin(request.Email);

            if (loginUtilizado == false)
            {
                var parceiro = ParceiroEntity.Criar(dto);
                await _repository.CadastrarParceiro(parceiro);
            }
            else
            {
                throw new DomainException("Email já utilizado!");
            }

            return Unit.Value;
        }
    }
}
