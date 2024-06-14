namespace Bookify.Application.Abstractions.Email;

public interface IEmailService
{
    Task SendAsync(Domain.Features.Users.Email recipient, string subject, string body);
}