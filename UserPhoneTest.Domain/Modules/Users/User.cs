using UserPhoneTest.Domain.Abstractions;
using UserPhoneTest.Domain.Modules.Phones;

namespace UserPhoneTest.Domain.Modules.Users;

public class User : Entity
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public List<Phone>? Phones { get; set; }
}