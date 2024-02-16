using BloodBank.Application.Commands.UpdateBloodStock;
using BloodBank.Application.Queries.GetBloodStokReport;
using BloodBank.Domain.Enums;
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

        [HttpGet("report")]
        public async Task<IActionResult> GetReport([FromQuery] BloodType type)
        {
            var result = await _mediator.Send(new GetBloodStockReportQuery(type));
            return Content(result.Data.ToString(), "text/csv");
        }
    }
}
