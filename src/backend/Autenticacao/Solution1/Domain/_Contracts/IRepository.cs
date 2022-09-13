using Domain._Contracts.Response;
using System.Threading.Tasks;

namespace Domain._Contracts
{
    public interface IRepository
    {
        Task Adicionar(Usuario entity);

        Task<UsuarioResponse> Obter(string login, string senha);
        Task<bool> Existe(string login);

    }
}
