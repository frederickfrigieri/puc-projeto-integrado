using Domain._Contracts.Dto;
using System.Threading.Tasks;

namespace Domain._Contracts
{
    public interface IIdentidade
    {
        Task CadastrarUsuario(NovoAcessoDto acesso);
    }
}
