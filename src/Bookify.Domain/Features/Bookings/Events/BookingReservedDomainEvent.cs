using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Features.Bookings.Events;

public sealed record BookingReservedDomainEvent(Guid BookingId) : IDomainEvent;