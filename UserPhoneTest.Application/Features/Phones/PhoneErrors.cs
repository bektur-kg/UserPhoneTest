using UserPhoneTest.Application.Abstractions;

namespace UserPhoneTest.Application.Features.Phones;

public static class PhoneErrors
{
    public static readonly Error PhoneExists = new("Phone.Exists", "This phone already taken");
    public static readonly Error PhoneNotFound = new("Phone.PhoneNotFound", "Phone with this Id not found");
}
