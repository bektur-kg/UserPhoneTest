using UserPhoneTest.Application.Services;
using UserPhoneTest.Infrastructure.DbContexts;

namespace UserPhoneTest.Infrastructure.Services;

public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => dbContext.SaveChangesAsync(cancellationToken);
}
