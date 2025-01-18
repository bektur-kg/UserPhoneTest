
using CSharpFunctionalExtensions;
using UserPhoneTest.Application.Abstractions;

namespace UserPhoneTest.Application.Features.Users.Delete;

public record DeleteUserCommand(int UserId) : ICommand<UnitResult<Error>>;