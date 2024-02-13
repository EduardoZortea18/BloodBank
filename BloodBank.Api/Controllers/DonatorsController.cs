using BloodBank.Application.Commands.CreateDonator;
using BloodBank.Application.Queries.GetDonator;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Api.Controllers
{
    [Route("api/donators")]
    [ApiController]
    public class DonatorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DonatorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDonatorCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.HasError)
            {
                return BadRequest(result.ErrorMessage);
            }

            return CreatedAtAction(nameof(Get), new { Id = result.Data }, command);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetDonatorQuery(id));

            if (response.HasError)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
