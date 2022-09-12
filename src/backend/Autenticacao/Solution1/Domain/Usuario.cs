using Domain._Contracts.Dto;
using System;

namespace Domain
{
    public class Usuario : Entity
    {
        private Usuario(Guid chave, string login, string password)
        {
            //Todo Validar se já existe login

            Chave = chave;
            Login = login;
            Password = password;
        }

        public Guid Chave { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }

        public static Usuario Cadastrar(NovoAcessoDto dto)
        {
            var novoUsuario = new Usuario(dto.Chave, dto.Login, dto.Password);

            return novoUsuario;
        }
    }
}
