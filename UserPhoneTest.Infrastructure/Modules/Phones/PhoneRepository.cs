using Microsoft.EntityFrameworkCore;
using UserPhoneTest.Application.Repositories;
using UserPhoneTest.Domain.Modules.Phones;
using UserPhoneTest.Infrastructure.DbContexts;
using UserPhoneTest.Infrastructure.Services;

namespace UserPhoneTest.Infrastructure.Modules.Phones;

public class PhoneRepository(AppDbContext dbContext) : BaseRepository<Phone>(dbContext), IPhoneRepository
{
    public Task<bool> DoesPhoneExistAsync(string phone, CancellationToken cancellationToken = default)
    {
        return DbContext.Phones.AnyAsync(p => p.PhoneNumber == phone, cancellationToken);
    }

    public Task<List<Phone>> GetUserPhonesAsync(int userId, CancellationToken cancellationToken = default)
    {
        return DbContext.Phones
            .AsNoTracking()
            .Where(p => p.UserId == userId)
            .ToListAsync(cancellationToken);
    }
}
