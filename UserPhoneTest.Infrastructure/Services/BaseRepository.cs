using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using UserPhoneTest.Application.Abstractions;
using UserPhoneTest.Infrastructure.DbContexts;

namespace UserPhoneTest.Infrastructure.Services;

public abstract class BaseRepository<TEntity>(AppDbContext dbContext) : IRepository<TEntity> where TEntity : Entity<int>
{
    protected AppDbContext DbContext = dbContext;

    #region ReadOnly

    public Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default) => DbContext
        .Set<TEntity>()
        .AsNoTracking()
        .ToListAsync(cancellationToken);

    public Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default) => DbContext
        .Set<TEntity>()
        .AsNoTracking()
        .FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);

    #endregion

    #region WriteOnly

    public Task<TEntity?> GetByIdAsyncWithTracking(int id, CancellationToken cancellationToken = default) => DbContext
        .Set<TEntity>()
        .FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);

    public void Remove(TEntity entity) => DbContext
        .Set<TEntity>()
        .Remove(entity);

    public void Add(TEntity entity) => DbContext.Add(entity);

    #endregion
}
