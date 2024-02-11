using BloodBank.Application.Commands.CreateDonator;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.Api.Controllers
{
    [Route("api/[controller]")]
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
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.SelectMany(x => x.Value!.Errors).Select(x => x.ErrorMessage).ToList();
                return BadRequest(errorMessages);
            }

            var id = await _mediator.Send(command);

            return CreatedAtAction(string.Empty, new { Id = id }, command);
        }
    }
}
