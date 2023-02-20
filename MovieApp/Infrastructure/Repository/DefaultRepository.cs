using Domain.Entities;
using Infrastructure.Contract;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class DefaultRepository<T> : IRepository<T> where T : class, IEntity
{
    private readonly AuthorizationDbContext _dbContext;

    protected DbSet<T> Table => _dbContext.Set<T>();

    public DefaultRepository(AuthorizationDbContext dbContext) => _dbContext = dbContext;

    public virtual async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await Table.FirstAsync(entity => entity.Id == id, cancellationToken);

        Table.Remove(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task<T?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await Table.FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);

        return entity;
    }

    public virtual IQueryable<T> GetAll() => Table;

    public virtual async Task InsertAsync(T entity, CancellationToken cancellationToken)
    {
        Table.Add(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        Table.Update(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}