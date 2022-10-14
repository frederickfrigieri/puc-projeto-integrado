using System.Threading.Tasks;
using Application.Queries.ObterArmazens;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/armazens")]
    [ApiController]
    [Authorize]
    public class DarkStoreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DarkStoreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ObterProdutosPorParceiro()
        {
            var query = new ObterArmazemQuery();
            var armazens = await _mediator.Send(query);

            return Ok(armazens);
        }
    }
}
