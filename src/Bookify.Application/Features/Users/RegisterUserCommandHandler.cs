using Bookify.Application.Abstractions.Authentication;
using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Features.Users;

namespace Bookify.Application.Features.Users;

internal sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Guid>
{
    public RegisterUserCommandHandler(IAuthenticationService authenticationService, IUserRepository repository, IUnitOfWork uow)
    {
        _authenticationService = authenticationService;
        _repository = repository;
        _uow = uow;
    }

    private readonly IAuthenticationService _authenticationService;
    private readonly IUserRepository _repository;
    private readonly IUnitOfWork _uow;

    public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = User.Create(
            new FirstName(request.FirstName),
            new LastName(request.LastName),
            new Email(request.Email));

        var identity = await _authenticationService.RegisterAsync(
            user,
            request.Password,
            cancellationToken);

        user.SetIdentityId(identity);

        _repository.Add(user);

        await _uow.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
