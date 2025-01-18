using UserPhoneTest.Application.Repositories;
using UserPhoneTest.Domain.Modules.Users;
using UserPhoneTest.Infrastructure.DbContexts;
using UserPhoneTest.Infrastructure.Services;

namespace UserPhoneTest.Infrastructure.Modules.Users;

public class UserRepository(AppDbContext dbContext) : BaseRepository<User>(dbContext), IUserRepository
{
}
