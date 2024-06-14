using Bookify.Api.Shared;
using Bookify.Application.Features.Bookings.GetBooking;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Api.Controllers.Bookings;

[ApiController]
[Route("api/bookings")]
public class BookingController(ISender bus) : BookifyControllerBase(bus)
{
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken=default)
    {
        var query = new GetBookingQuery(id);

        var result = await Bus.Send(query, cancellationToken);

        return result.IsFailure
            ? NotFound()
            : Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> Reserve([FromBody] RequestBookingRequest request, CancellationToken cancellationToken = default)
    {
        var command = request.ToCommand();

        var result = await Bus.Send(command, cancellationToken);

        return result.IsFailure
            ? BadRequest(result.Error)
            : CreatedAtAction(nameof(Get), new { id = result.Value }, result.Value);
    }
}
