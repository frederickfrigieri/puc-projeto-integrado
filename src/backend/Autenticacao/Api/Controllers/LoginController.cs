using Application.Services.Request;
using Domain._Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAutenticacao _autenticacao;

        public LoginController(IAutenticacao autenticacao)
        {
            _autenticacao = autenticacao;
        }

        [HttpPost]

        public async Task<IActionResult> Post([FromBody] LoginRequest request)
        {
            var token = await _autenticacao.AutenticarAsync(request.Login, request.Password);

            if (token.Token == string.Empty)
                return NotFound("Usuario nao encontrado!");

            return Ok(token);
        }

        [HttpGet]
        [Route("logado")]
        [Authorize]
        public IActionResult Logado()
        {
            return Ok(new { logado = true });
        }
    }
}
