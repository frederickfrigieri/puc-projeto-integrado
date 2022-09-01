using System;
using System.Threading.Tasks;
using Application.Commands.CadastrarProduto;
using Application.ObterProdutosPorParceiro;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/parceiros")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProdutoController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("{chaveParceiro}/produtos")]
        public async Task<IActionResult> Postar([FromBody] CadastrarProdutoRequest request)
        {
            var command = _mapper.Map<CadastrarProdutoCommand>(request);

            var chave = await _mediator.Send(command);

            return Ok(chave);
        }

        [HttpGet]
        [Route("{chaveParceiro}/produtos")]
        public async Task<IActionResult> ObterProdutosPorParceiro([FromRoute] Guid chaveParceiro)
        {
            var query = new ObterProdutosPorParceiroQuery(chaveParceiro);
            var produtos = await _mediator.Send(query);

            return Ok(produtos);
        }
    }
}
