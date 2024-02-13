using BloodBank.Application.Commands.CreateDonation;
using BloodBank.Application.Queries.GetDonation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Api.Controllers
{
    [Route("api/donations")]
    [ApiController]
    public class DonationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DonationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDonationCommand command)
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
            var response = await _mediator.Send(new GetDonationQuery(id));

            if (response.HasError)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
