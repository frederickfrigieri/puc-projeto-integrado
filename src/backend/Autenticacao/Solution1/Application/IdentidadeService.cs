using Domain;
using Domain._Contracts;
using Domain._Contracts.Dto;
using System.Threading.Tasks;

namespace Application
{
    public class IdentidadeService : IIdentidade
    {
        private readonly IRepository _repository;

        public IdentidadeService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task CadastrarUsuario(NovoAcessoDto acesso)
        {
            var existe = await _repository.Obter(acesso.Login, acesso.Password);

            if (existe == null)
                await _repository.Adicionar(Usuario.Cadastrar(acesso));
        }
    }
}
