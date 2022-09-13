using Application.Services;
using Application.Services.Contracts;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Http
{
    public class AutenticacaoService : IAutenticacao
    {
        private HttpClient _httpClient;

        public AutenticacaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> Cadastrar(AutenticacaoRequest dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var model = new StringContent(json, Encoding.UTF8, "application/json");
            var endpoint = $"{_httpClient.BaseAddress}/identidade";

            var response = await _httpClient.PostAsync(endpoint, model);

            return response;
        }

        public async Task<bool> ExisteLogin(string login)
        {
            var endpoint = $"{_httpClient.BaseAddress}/identidade/existe-login?login={login}";

            var response = await _httpClient.GetStringAsync(endpoint);

            return bool.Parse(response);
        }
    }
}
