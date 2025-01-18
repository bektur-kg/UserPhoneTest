using CSharpFunctionalExtensions;
using UserPhoneTest.Application.Abstractions;
using UserPhoneTest.Application.Contracts.Users;

namespace UserPhoneTest.Application.Features.Users.Create;

public record CreateUserCommand(CreateUserRequest Data) : ICommand<UnitResult<Error>>;
