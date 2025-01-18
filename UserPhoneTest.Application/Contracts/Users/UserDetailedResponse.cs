using UserPhoneTest.Application.Contracts.Phones;

namespace UserPhoneTest.Application.Contracts.Users;

public record UserDetailedResponse
{
    public int Id { get; init; }

    public required string Name { get; init; }

    public required string Email { get; init; }

    public DateOnly DateOfBirth { get; init; }

    public List<PhoneResponse> Phones { get; init; } = [];
}