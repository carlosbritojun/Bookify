using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Features.Users.Events;

public sealed record UserCreatedDomainEvent(Guid userId) : IDomainEvent;