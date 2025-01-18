namespace UserPhoneTest.Application.Contracts.Users;

public record UserResponse
{
    public required string Name { get; init; }

    public required string Email { get; init; }

    public DateOnly DateOfBirth { get; init; }
}
