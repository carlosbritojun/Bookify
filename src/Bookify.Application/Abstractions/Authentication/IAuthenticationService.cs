using Bookify.Domain.Features.Users;

namespace Bookify.Application.Abstractions.Authentication;

public interface IAuthenticationService
{
    Task<string> RegisterAsync(User user, object password, CancellationToken cancellationToken=default);
}