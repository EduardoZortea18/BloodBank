using BloodBank.Application.Commands.UpdateBloodStock;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Api.Controllers
{
    [Route("api/blood-stocks")]
    [ApiController]
    public class BloodStocksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BloodStocksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBloodStockCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.HasError)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result);
        }
    }
}
