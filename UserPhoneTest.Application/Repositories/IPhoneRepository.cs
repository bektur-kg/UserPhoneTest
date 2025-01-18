using UserPhoneTest.Application.Abstractions;
using UserPhoneTest.Domain.Modules.Phones;

namespace UserPhoneTest.Application.Repositories;

public interface IPhoneRepository : IReadRepository<Phone>, IWriteRepository<Phone>
{
}
