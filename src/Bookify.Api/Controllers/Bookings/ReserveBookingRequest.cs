using Bookify.Application.Features.Bookings.ReserveBooking;

namespace Bookify.Api.Controllers.Bookings;

public sealed record RequestBookingRequest(
    Guid ApartmentId,
    Guid UserId,
    DateOnly StartDate,
    DateOnly EndDate)
{
    public ReserveBookingCommand ToCommand() => new(ApartmentId, UserId, StartDate, EndDate);
}