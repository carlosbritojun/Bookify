using Bookify.Application.Features.Users;

namespace Bookify.Api.Controllers.Users
{
    public class RegisterUserRequest(
        string FirstName,
        string LastName,
        string Email,
        string Password)
    {
        public RegisterUserCommand ToCommand() => new(FirstName, LastName, Email, Password);
    }
}