using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Features.Bookings.Events;

public sealed record BookingConfirmedDomainEvent(Guid bookingId) : IDomainEvent;
