using FluentResults;
using Huginn.Common.Enums;
using Huginn.Common.Extensions;
using Huginn.Database.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static FluentResults.Result;

namespace Huginn.Database.Common;

internal abstract class BaseRepository<TEntity>(ILogger<IRepository<TEntity>> logger, HuginnDbContext context) : IRepository<TEntity> where TEntity : class, IEntity
{
    protected readonly ILogger _logger = logger;
    protected readonly HuginnDbContext _context = context;
    protected readonly DbSet<TEntity> _set = context.Set<TEntity>();
    
    public async Task<Result<TEntity>> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        try
        {
            _set.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogEntityAdded(nameof(TEntity), entity.Id);
            
            return Ok(entity);
        }
        catch (Exception exception)
        {
            _logger.LogEntityAddError(nameof(TEntity), entity.Id, exception);

            return Fail(exception.Message);
        }
    }

    public async Task<Result<TEntity>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _set.FirstOrDefaultAsync(entity => entity.Id.Equals(id), cancellationToken);
        
        return entity is not null ? Ok(entity) : Result.WithErrorCode(ErrorCodes.EntityNotFound);
    }

    public async Task<Result<TEntity>> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        try
        {
            _set.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogEntityUpdated(nameof(TEntity), entity.Id);
            
            return Ok(entity);
        }
        catch (Exception exception)
        {
            _logger.LogEntityUpdateError(nameof(TEntity), entity.Id, exception);
            
            return Fail(exception.Message);
        }
    }

    public async Task<Result<TEntity>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _set.FirstOrDefaultAsync(entity => entity.Id.Equals(id), cancellationToken);

        if (entity is null)
        {
            return Result.WithSuccessCode(ErrorCodes.EntityNotFound);
        }

        try
        {
            _logger.LogEntityDeleted(nameof(TEntity), entity.Id);
            _set.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            
            return Ok(entity);
        }
        catch (Exception exception)
        {
            _logger.LogEntityDeleteError(nameof(TEntity), entity.Id, exception);
            
            return Fail(exception.Message);
        }
    }

    public async Task<Result<IEnumerable<TEntity>>> GetPaginetedAsync(int page, int size, CancellationToken cancellationToken = default)
    {
        var result = await _set.Skip(size * page).Take(page).ToListAsync(cancellationToken);

        return result.Count is 0? Ok(result.AsEnumerable()) : Fail("Not Found");
    }
}