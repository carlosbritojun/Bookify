using Bookify.Domain.Features.Apartments;

namespace Bookify.Infrastructure.Data.Repositories;

internal sealed class ApartmentRepository : Repository<Apartment>, IApartmentRepository
{
    public ApartmentRepository(ApplicationDbContext db) : base(db)
    {
    }
}
