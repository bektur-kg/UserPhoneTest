using UserPhoneTest.Application.Repositories;
using UserPhoneTest.Domain.Modules.Phones;
using UserPhoneTest.Infrastructure.DbContexts;
using UserPhoneTest.Infrastructure.Services;

namespace UserPhoneTest.Infrastructure.Modules.Phones;

public class PhoneRepository(AppDbContext dbContext) : BaseRepository<Phone>(dbContext), IPhoneRepository
{
}
