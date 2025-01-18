using AutoMapper;
using CSharpFunctionalExtensions;
using UserPhoneTest.Application.Abstractions;
using UserPhoneTest.Application.Contracts.Phones;
using UserPhoneTest.Application.Features.Users;
using UserPhoneTest.Application.Repositories;

namespace UserPhoneTest.Application.Features.Phones.GetAllUserPhones;

internal sealed class GetUserPhonesQueryHandler(
    IUserRepository userRepository,
    IMapper mapper,
    IPhoneRepository phoneRepository)
    : IQueryHandler<GetUserPhonesQuery, Result<List<PhoneResponse>, Error>>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IPhoneRepository _phoneRepository = phoneRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<Result<List<PhoneResponse>, Error>> Handle(GetUserPhonesQuery request, CancellationToken cancellationToken)
    {
        var doesUserExist = await _userRepository.DoesUserExistAsync(request.UserId, cancellationToken);

        if (!doesUserExist) return Result.Failure<List<PhoneResponse>, Error>(UserErrors.UserNotFound);

        var userPhones = await _phoneRepository.GetUserPhonesAsync(request.UserId, cancellationToken);
        var mappedUserPhones = _mapper.Map<List<PhoneResponse>>(userPhones);

        return Result.Success<List<PhoneResponse>, Error>(mappedUserPhones);
    }
}
