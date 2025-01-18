using UserPhoneTest.Application.Abstractions;
using UserPhoneTest.Domain.Modules.Users;

namespace UserPhoneTest.Application.Repositories;

public interface IUserRepository : IReadRepository<User>, IWriteRepository<User>
{
    Task<bool> DoesUserExistAsync(string email, CancellationToken cancellationToken = default);

    Task<bool> DoesUserExistAsync(int userId, CancellationToken cancellationToken = default);

    Task<User?> GetByIdAsyncWithInclude(int id, bool includePhones = false, CancellationToken cancellationToken = default);
}
