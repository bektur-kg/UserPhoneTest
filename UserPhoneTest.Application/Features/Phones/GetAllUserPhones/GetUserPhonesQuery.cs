using CSharpFunctionalExtensions;
using UserPhoneTest.Application.Abstractions;
using UserPhoneTest.Application.Contracts.Phones;

namespace UserPhoneTest.Application.Features.Phones.GetAllUserPhones;

public record GetUserPhonesQuery(int UserId) : IQuery<Result<List<PhoneResponse>, Error>>;