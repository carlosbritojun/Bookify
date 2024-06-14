using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.Features.Users;

public sealed record RegisterUserCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : ICommand<Guid>;
