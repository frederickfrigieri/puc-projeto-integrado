using Application.Services.Request;
using Domain._Contracts;
using Domain._Contracts.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/identidade")]
    [ApiController]
    public class IdentidadeController : ControllerBase
    {
        private readonly IIdentidade _identidade;

        public IdentidadeController(IIdentidade identidade)
        {
            _identidade = identidade;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NovaIdentidadeDto request)
        {
            var dto = new NovoAcessoDto
            {
                Chave = Guid.Parse(request.ChaveParceiro),
                Login = request.Login,
                Password = request.Password
            };

            await _identidade.CadastrarUsuario(dto);

            return Ok();
        }

        [HttpGet]
        [Route("existe-login")]
        public async Task<IActionResult> ExisteLogin([FromQuery] string login)
        {
            var response = await _identidade.ExisteLogin(login);

            return Ok(response);
        }
    }
}
