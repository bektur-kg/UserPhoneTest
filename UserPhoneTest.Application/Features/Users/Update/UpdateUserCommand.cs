using CSharpFunctionalExtensions;
using UserPhoneTest.Application.Abstractions;
using UserPhoneTest.Application.Contracts.Users;

namespace UserPhoneTest.Application.Features.Users.Update;

public record UpdateUserCommand(int userId, UpdateUserRequest Data) : ICommand<UnitResult<Error>>;
