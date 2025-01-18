using CSharpFunctionalExtensions;
using UserPhoneTest.Application.Abstractions;

namespace UserPhoneTest.Application.Features.Phones.DeleteUserPhone;

public record DeleteUserPhoneCommand(int PhoneId) : ICommand<UnitResult<Error>>;