using System.ComponentModel.DataAnnotations;
using UserPhoneTest.Domain.Modules.Phones;

namespace UserPhoneTest.Application.Contracts.Phones;

public record AddUserPhoneRequest
{
    [RegularExpression(PhoneAttributeConstants.InternationalPhoneRegex)]
    [MaxLength(PhoneAttributeConstants.PhoneNumberMaxLength)]
    public required string PhoneNumber { get; init; }

    public int UserId { get; init; }
}
