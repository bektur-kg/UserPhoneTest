namespace UserPhoneTest.Application.Contracts.Phones;

public record PhoneResponse
{
    public required string PhoneNumber { get; init; }

    public int UserId { get; init; }
}
