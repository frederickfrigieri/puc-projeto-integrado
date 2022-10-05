using Application.Services.Dto;
using Domain;
using Domain._Contracts;
using Domain._Contracts.Dto;
using Domain._Contracts.Response;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Application
{
    public class AutenticacaoService : IAutenticacao
    {
        private readonly IRepository _repository;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        public AutenticacaoService(
            IRepository repository,
            ITokenService tokenService,
            IConfiguration configuration)
        {
            _repository = repository;
            _tokenService = tokenService;
            _configuration = configuration;
        }

        public async Task<TokenResponse> AutenticarAsync(string login, string password)
        {
            var usuario = await _repository.Obter(login, password);

            if (usuario == null)
                return new TokenResponse { Token = string.Empty };


            var jwtSecrets = _configuration.GetSection("JWTSecretToken").Value;
            var tokenProperties = new TokenPropertiesDto
            {
                Chave = usuario.ChaveUsuario,
                Data = DateTime.Now,
                Login = login,
                Perfil = usuario.Perfil
            };

            var token = _tokenService.GerarToken(tokenProperties, jwtSecrets);

            return new TokenResponse { Token = token };
        }

        public async Task CadastrarUsuario(NovoAcessoDto acesso)
        {
            await _repository.Adicionar(Usuario.Cadastrar(acesso));
        }
    }
}
