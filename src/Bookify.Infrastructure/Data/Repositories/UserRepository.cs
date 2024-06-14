using Bookify.Domain.Features.Users;

namespace Bookify.Infrastructure.Data.Repositories;

internal sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext db) : base(db)
    {
    }
}
