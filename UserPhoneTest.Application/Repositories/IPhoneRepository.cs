using UserPhoneTest.Application.Abstractions;
using UserPhoneTest.Domain.Modules.Phones;

namespace UserPhoneTest.Application.Repositories;

public interface IPhoneRepository : IReadRepository<Phone>, IWriteRepository<Phone>
{
    Task<List<Phone>> GetUserPhonesAsync(int userId, CancellationToken cancellationToken = default);

    Task<bool> DoesPhoneExistAsync(string phone, CancellationToken cancellationToken = default);
}
