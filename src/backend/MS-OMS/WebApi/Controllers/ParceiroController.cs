using System;
using System.Threading.Tasks;
using Application.Commands.CadastrarParceiro;
using Application.ObterParceiro;
using Application.ObterParceiros;
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
        [Route("{chaveParceiro}")]
        public async Task<IActionResult> ObterPorChave([FromRoute] Guid chaveParceiro)
        {
            var query = new ObterParceiroQuery(chaveParceiro);

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> ObterTodos()
        {
            var query = new ObterParceirosQuery();

            var response = await _mediator.Send(query);

            return Ok(response);
        }

    }
}
