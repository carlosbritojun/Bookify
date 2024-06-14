using Bookify.Api.Shared;
using Bookify.Application.Features.Apartments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Api.Controllers.Apartments;

[Authorize]
[ApiController]
[Route("api/apartments")]
public class ApartmentController(ISender bus) : BookifyControllerBase(bus)
{
    [HttpGet]
    public async Task<ActionResult> Search(DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken = default)
    {
        var query = new SearchApartmentsQuery(startDate, endDate);

        var result = await Bus.Send(query, cancellationToken);

        return Ok(result.Value);

        //return Ok(new { startDate, endDate });
    }
}
