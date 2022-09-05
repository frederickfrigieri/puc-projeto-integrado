using System;
using System.Threading.Tasks;
using Application.Commands.CadastrarPedido;
using Application.ObterPedidosPorParceiro;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/parceiros")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PedidoController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("{chaveParceiro}/pedidos")]
        public async Task<IActionResult> Postar([FromBody] CadastrarPedidoRequest request)
        {
            var command = _mapper.Map<CadastrarPedidoCommand>(request);

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpGet]
        [Route("{chaveParceiro}/pedidos")]
        public async Task<IActionResult> ObterPedidosPorParceiro([FromRoute] Guid chaveParceiro)
        {
            var query = new ObterPedidosPorParceiroQuery(chaveParceiro);

            var response = await _mediator.Send(query);

            return Ok(response);
        }
    }
}
