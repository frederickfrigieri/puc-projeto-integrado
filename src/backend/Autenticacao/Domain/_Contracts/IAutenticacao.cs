using Domain._Contracts.Dto;
using Domain._Contracts.Response;
using System.Threading.Tasks;

namespace Domain._Contracts
{
    public interface IAutenticacao
    {
        Task<TokenResponse> AutenticarAsync(string login, string password);
    }
}
