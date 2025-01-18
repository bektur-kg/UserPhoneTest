using CSharpFunctionalExtensions;

namespace UserPhoneTest.Application.Abstractions;

public interface IReadRepository<TEntity> where TEntity : Entity<int>
{
    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
}
