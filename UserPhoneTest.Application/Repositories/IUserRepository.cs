using UserPhoneTest.Application.Abstractions;
using UserPhoneTest.Domain.Modules.Users;

namespace UserPhoneTest.Application.Repositories;

public interface IUserRepository : IReadRepository<User>, IWriteRepository<User>
{
}
