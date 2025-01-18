using CSharpFunctionalExtensions;

namespace UserPhoneTest.Application.Abstractions;

public interface IRepository<TEntity> : IReadRepository<TEntity>, IWriteRepository<TEntity>
    where TEntity : Entity<int>;
