using CSharpFunctionalExtensions;
using UserPhoneTest.Application.Abstractions;
using UserPhoneTest.Application.Features.Users;
using UserPhoneTest.Application.Repositories;
using UserPhoneTest.Application.Services;
using UserPhoneTest.Domain.Modules.Phones;

namespace UserPhoneTest.Application.Features.Phones.AddUserPhone;

internal sealed class AddUserPhoneCommandHandler(
    IUserRepository userRepository,
    IPhoneRepository phoneRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<AddUserPhoneCommand, UnitResult<Error>>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IPhoneRepository _phoneRepository = phoneRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<UnitResult<Error>> Handle(AddUserPhoneCommand request, CancellationToken cancellationToken)
    {
        var doesUserExists = await _userRepository.DoesUserExistAsync(request.Data.UserId, cancellationToken);

        if (!doesUserExists) return UnitResult.Failure(UserErrors.UserNotFound);

        var doesPhoneExist = await _phoneRepository.DoesPhoneExistAsync(request.Data.PhoneNumber, cancellationToken);

        if (doesPhoneExist) return UnitResult.Failure(PhoneErrors.PhoneExists);

        var newUserPhone = new Phone()
        { 
            PhoneNumber = request.Data.PhoneNumber,
            UserId = request.Data.UserId
        };

        _phoneRepository.Add(newUserPhone);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return UnitResult.Success<Error>();
    }
}
