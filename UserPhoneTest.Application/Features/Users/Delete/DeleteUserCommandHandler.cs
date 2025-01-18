using CSharpFunctionalExtensions;
using UserPhoneTest.Application.Abstractions;
using UserPhoneTest.Application.Repositories;
using UserPhoneTest.Application.Services;

namespace UserPhoneTest.Application.Features.Users.Delete;

internal sealed class DeleteUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteUserCommand, UnitResult<Error>>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<UnitResult<Error>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var foundUser = await _userRepository.GetByIdAsyncWithTracking(request.UserId, cancellationToken);

        if (foundUser is null) return UnitResult.Failure(UserErrors.UserNotFound);

        _userRepository.Remove(foundUser);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return UnitResult.Success<Error>();
    }
}
