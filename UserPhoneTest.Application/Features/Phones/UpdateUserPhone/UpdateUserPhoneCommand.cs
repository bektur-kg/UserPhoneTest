using CSharpFunctionalExtensions;
using UserPhoneTest.Application.Abstractions;
using UserPhoneTest.Application.Contracts.Phones;

namespace UserPhoneTest.Application.Features.Phones.UpdateUserPhone;

public record UpdateUserPhoneCommand(UpdatePhoneRequest Data) : ICommand<UnitResult<Error>>;
