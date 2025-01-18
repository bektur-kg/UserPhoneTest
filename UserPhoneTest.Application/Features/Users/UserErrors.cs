using UserPhoneTest.Application.Abstractions;

namespace UserPhoneTest.Application.Features.Users;

public static class UserErrors
{
    public static readonly Error UserExists = new("User.Exists", "User with this email already exists");
    public static readonly Error UserNotFound = new("User.UserNotFound", "User with this Id not found");
}
