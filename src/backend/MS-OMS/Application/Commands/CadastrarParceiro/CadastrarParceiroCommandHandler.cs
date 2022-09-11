using Application._Configuration.Commands;
using Domain;
using Domain.Dtos;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.CadastrarParceiro
{
    public class CadastrarParceiroCommandHandler : ICommandHandler<CadastrarParceiroCommand>
    {
        private readonly IRepository _repository;

        public CadastrarParceiroCommandHandler(IRepository repository)
        {
            _repository = repository;
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

            var parceiro = ParceiroEntity.Criar(dto);

            await _repository.CadastrarParceiro(parceiro);

            return Unit.Value;
        }
    }
}
