using CSharpFunctionalExtensions;
using UserPhoneTest.Application.Abstractions;
using UserPhoneTest.Application.Contracts.Users;

namespace UserPhoneTest.Application.Features.Users.GetById;

public record GetUserQuery(int UserId) : IQuery<Result<UserResponse, Error>>;
