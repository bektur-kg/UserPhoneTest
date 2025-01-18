using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations;
using UserPhoneTest.Domain.Modules.Users;

namespace UserPhoneTest.Domain.Modules.Phones;

public class Phone : Entity<int>
{
    [RegularExpression(PhoneAttributeConstants.InternationalPhoneRegex)]
    [MaxLength(PhoneAttributeConstants.PhoneNumberMaxLength)]
    public required string PhoneNumber { get; set; }

    public int UserId { get; set; }

    public User? User { get; set; }
}