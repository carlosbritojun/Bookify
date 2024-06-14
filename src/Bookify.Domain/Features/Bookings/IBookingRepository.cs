using Bookify.Domain.Features.Apartments;

namespace Bookify.Domain.Features.Bookings;

public interface IBookingRepository
{
    void Add(Booking booking);
    Task<Booking?> GetByIdAsync(Guid userId, CancellationToken cancellationToken);
    Task<bool> IsOverlappingAsync(Apartment apartment, DateRange duration, CancellationToken cancellationToken);
}
