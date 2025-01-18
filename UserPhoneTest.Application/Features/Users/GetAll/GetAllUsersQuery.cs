using CSharpFunctionalExtensions;
using UserPhoneTest.Application.Abstractions;
using UserPhoneTest.Application.Contracts.Users;

namespace UserPhoneTest.Application.Features.Users.GetAll;

public sealed record GetAllUsersQuery : IQuery<Result<List<UserResponse>>>;