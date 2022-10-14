using System;
using System.Threading.Tasks;
using Application.Commands.CadastrarEstoque;
using Application.Queries.ObterEstoques;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/parceiros")]
    [ApiController]
    [Authorize]
    public class EstoqueController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public EstoqueController(
            IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("{chaveParceiro}/estoques")]
        public async Task<IActionResult> CadastrarEstoque([FromBody] CadastrarEstoqueRequest request)
        {
            var comando = _mapper.Map<CadastrarEstoqueCommand>(request);
            var estoque = await _mediator.Send(comando);

            return Ok(estoque);
        }

        [HttpGet]
        [Route("{chaveParceiro}/estoques")]
        public async Task<IActionResult> ObterEstoques([FromRoute] Guid chaveParceiro)
        {
            var query = new ObterEstoquesQuery(chaveParceiro);
            var estoque = await _mediator.Send(query);

            return Ok(estoque);
        }

    }
}
