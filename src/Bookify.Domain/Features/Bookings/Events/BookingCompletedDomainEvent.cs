using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Features.Bookings.Events;

public sealed record BookingCompletedDomainEvent(Guid bookingId) : IDomainEvent;
