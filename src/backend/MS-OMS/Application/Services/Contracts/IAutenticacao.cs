using System.Net.Http;
using System.Threading.Tasks;

namespace Application.Services.Contracts
{
    public interface IAutenticacao
    {
        Task<HttpResponseMessage> Cadastrar(AutenticacaoRequest dto);
        Task<bool> ExisteLogin(string login);
    }
}
