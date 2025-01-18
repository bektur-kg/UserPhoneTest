using CSharpFunctionalExtensions;
using UserPhoneTest.Application.Abstractions;
using UserPhoneTest.Application.Repositories;
using UserPhoneTest.Application.Services;

namespace UserPhoneTest.Application.Features.Phones.DeleteUserPhone;

internal sealed class DeleteUserPhoneCommandHandler(IPhoneRepository phoneRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteUserPhoneCommand, UnitResult<Error>>
{
    private readonly IPhoneRepository _phoneRepository = phoneRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<UnitResult<Error>> Handle(DeleteUserPhoneCommand request, CancellationToken cancellationToken)
    {
        var foundPhone = await _phoneRepository.GetByIdAsync(request.PhoneId, cancellationToken);

        if (foundPhone is null) return UnitResult.Failure(PhoneErrors.PhoneNotFound);

        _phoneRepository.Remove(foundPhone);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return UnitResult.Success<Error>();
    }
}
