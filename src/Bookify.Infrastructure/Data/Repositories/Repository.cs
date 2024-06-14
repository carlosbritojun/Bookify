using Bookify.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Infrastructure.Data.Repositories;

internal abstract class Repository<T> where T : Entity
{
    protected Repository(ApplicationDbContext db)
    {
        Db = db;
    }
    
    protected readonly ApplicationDbContext Db;

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await Db
            .Set<T>()
            .FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
    }

    public void Add(T entity) => Db.Add(entity);
}
