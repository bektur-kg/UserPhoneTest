using CSharpFunctionalExtensions;
using UserPhoneTest.Application.Abstractions;
using UserPhoneTest.Application.Contracts.Phones;

namespace UserPhoneTest.Application.Features.Phones.AddUserPhone;

public record AddUserPhoneCommand(AddUserPhoneRequest Data) : ICommand<UnitResult<Error>>;