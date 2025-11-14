using FluentResults;

namespace Huginn.Database.Common;

public interface IRepository<TEntity> where TEntity : class, IEntity
{
    public Task<Result<TEntity>> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    
    public Task<Result<TEntity>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    public Task<Result<TEntity>> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    
    public Task<Result<TEntity>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    
    public Task<Result<IEnumerable<TEntity>>> GetPaginetedAsync(int page, int size, CancellationToken cancellationToken = default);
}
