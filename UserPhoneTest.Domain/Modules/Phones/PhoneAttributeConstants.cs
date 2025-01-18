namespace UserPhoneTest.Domain.Modules.Phones;

public abstract class PhoneAttributeConstants
{
    /// <summary>
    /// Phone number regex. Example that matches: +996771123456
    /// </summary>
    public const string InternationalPhoneRegex = @"^\+[1-9]\d{1,14}$";

    public const int PhoneNumberMaxLength = 15;
}
