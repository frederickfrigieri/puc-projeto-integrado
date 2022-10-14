using System;
using System.Threading.Tasks;
using Application.Commands.CadastrarParceiro;
using Application.ObterParceiro;
using Application.ObterParceiros;
using Application.ObterProdutosPorParceiro;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/parceiros")]
    [ApiController]
    [Authorize]
    public class ParceiroController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ParceiroController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Postar([FromBody] CadastrarParceiroRequest request)
        {
            var command = _mapper.Map<CadastrarParceiroCommand>(request);

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Obter()
        {
            var query = new ObterParceirosQuery();

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpGet]
        [Route("produtos")]
        public async Task<IActionResult> ObterProdutos()
        {
            var query = new ObterProdutosQuery();

            var response = await _mediator.Send(query);

            return Ok(response);
        }
    }
}
