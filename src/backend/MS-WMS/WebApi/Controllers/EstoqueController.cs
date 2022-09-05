using System.Threading.Tasks;
using Application.Commands.CadastrarEstoque;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/estoques")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public EstoqueController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarEstoque([FromBody] CadastrarEstoqueRequest request)
        {

            var comando = _mapper.Map<CadastrarEstoqueCommand>(request);

            var estoque = await _mediator.Send(comando);

            return Ok(estoque);
        }
    }
}
