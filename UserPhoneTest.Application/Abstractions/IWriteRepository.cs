using CSharpFunctionalExtensions;

namespace UserPhoneTest.Application.Abstractions;

public interface IWriteRepository<TEntity> where TEntity : Entity<int>
{
    void Add(TEntity entity);

    void Remove(TEntity entity);

    Task<TEntity?> GetByIdAsyncWithTracking(int id, CancellationToken cancellationToken = default);
}
