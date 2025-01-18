namespace UserPhoneTest.Application.Contracts.Phones;

public record PhoneResponse
{
    public int Id { get; init; }

    public required string PhoneNumber { get; init; }
}
