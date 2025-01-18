using Microsoft.EntityFrameworkCore;
using UserPhoneTest.Application.Repositories;
using UserPhoneTest.Domain.Modules.Users;
using UserPhoneTest.Infrastructure.DbContexts;
using UserPhoneTest.Infrastructure.Services;

namespace UserPhoneTest.Infrastructure.Modules.Users;

public class UserRepository(AppDbContext dbContext) : BaseRepository<User>(dbContext), IUserRepository
{
    public Task<bool> DoesUserExistAsync(string email, CancellationToken cancellationToken = default)
    {
        return DbContext.Users.AnyAsync(u => u.Email == email, cancellationToken);
    }

    public Task<bool> DoesUserExistAsync(int userId, CancellationToken cancellationToken = default)
    {
        return DbContext.Users.AnyAsync(u => u.Id == userId, cancellationToken);
    }

    public Task<User?> GetByIdAsyncWithInclude(int id, bool includePhones = false, CancellationToken cancellationToken = default)
    {
        var query = DbContext.Users.AsNoTracking();

        if (includePhones) query.Include(u => u.Phones);

        return query.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    }
}
