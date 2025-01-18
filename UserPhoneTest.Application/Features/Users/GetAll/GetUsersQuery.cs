using CSharpFunctionalExtensions;
using UserPhoneTest.Application.Abstractions;
using UserPhoneTest.Application.Contracts.Users;

namespace UserPhoneTest.Application.Features.Users.GetAll;

public sealed record GetUsersQuery : IQuery<Result<List<UserResponse>>>;