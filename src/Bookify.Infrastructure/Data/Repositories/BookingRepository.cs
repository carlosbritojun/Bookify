using Bookify.Domain.Features.Apartments;
using Bookify.Domain.Features.Bookings;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Infrastructure.Data.Repositories;

internal sealed class BookingRepository : Repository<Booking>, IBookingRepository
{
    private static readonly BookingStatus[] ActiveBookingStatuses =
    {
        BookingStatus.Reserved,
        BookingStatus.Confirmed,
        BookingStatus.Completed
    };

    public BookingRepository(ApplicationDbContext db) : base(db)
    {
    }

    public async Task<bool> IsOverlappingAsync(Apartment apartment, DateRange duration, CancellationToken cancellationToken)
    {
        return await Db
            .Set<Booking>()
            .AnyAsync(booking =>
                booking.ApartmentId == apartment.Id &&
                booking.Duration.Start <= duration.End &&
                booking.Duration.End >= duration.Start &&
                ActiveBookingStatuses.Contains(booking.Status),

            cancellationToken);
    }
}
