using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations;
using UserPhoneTest.Domain.Modules.Phones;

namespace UserPhoneTest.Domain.Modules.Users;

public class User : Entity<int>
{
    [MaxLength(UserAttributeConstants.MaxNameLength)]
    public required string Name { get; set; }

    [EmailAddress]
    public required string Email { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public List<Phone> Phones { get; set; } = [];
}