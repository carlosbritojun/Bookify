using FluentValidation;

namespace Bookify.Application.Features.Users;

internal sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(newUser => newUser.FirstName).NotEmpty();
        RuleFor(newUser => newUser.LastName).NotEmpty();
        RuleFor(newUser => newUser.Email).EmailAddress();
        RuleFor(newUser => newUser.Password).NotEmpty().MaximumLength(5);
    }
}
