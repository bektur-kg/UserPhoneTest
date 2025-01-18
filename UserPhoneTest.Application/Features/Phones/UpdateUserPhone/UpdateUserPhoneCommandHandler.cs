using AutoMapper;
using CSharpFunctionalExtensions;
using UserPhoneTest.Application.Abstractions;
using UserPhoneTest.Application.Repositories;
using UserPhoneTest.Application.Services;

namespace UserPhoneTest.Application.Features.Phones.UpdateUserPhone;

internal sealed class UpdateUserPhoneCommandHandler(
    IPhoneRepository phoneRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateUserPhoneCommand, UnitResult<Error>>
{
    private readonly IPhoneRepository _phoneRepository = phoneRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<UnitResult<Error>> Handle(UpdateUserPhoneCommand request, CancellationToken cancellationToken)
    {
        var foundPhone = await _phoneRepository.GetByIdAsyncWithTracking(request.Data.Id, cancellationToken);

        if (foundPhone is null) return UnitResult.Failure(PhoneErrors.PhoneNotFound);

        foundPhone.PhoneNumber = request.Data.PhoneNumber;
        foundPhone.UserId = request.Data.UserId;

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return UnitResult.Success<Error>();
    }
}
