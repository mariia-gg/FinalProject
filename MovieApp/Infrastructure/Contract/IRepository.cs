using Domain.Entities;

namespace Infrastructure.Contract;

public interface IRepository<TEntity> where TEntity : IEntity
{
    Task<TEntity?> GetAsync(Guid id, CancellationToken cancellationToken);

    IQueryable<TEntity> GetAll();

    Task InsertAsync(TEntity entity, CancellationToken cancellationToken);

    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}