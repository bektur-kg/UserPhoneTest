namespace UserPhoneTest.Application.Contracts.Users;

public record UserResponse
{
    public int Id { get; init; }

    public required string Name { get; init; }

    public required string Email { get; init; }

    public DateOnly DateOfBirth { get; init; }
}
