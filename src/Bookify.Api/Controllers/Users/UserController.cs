using Bookify.Api.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Api.Controllers.Users;

[ApiController]
[Route("api/users")]
public class UserController(ISender bus) : BookifyControllerBase(bus)
{
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequest request, CancellationToken cancellationToken = default)
    {
        var command = request.ToCommand();

        var result = await Bus.Send(command, cancellationToken);

        return result.IsFailure
               ? BadRequest(result.Error)
               : Ok(result.Value);
    }
}
