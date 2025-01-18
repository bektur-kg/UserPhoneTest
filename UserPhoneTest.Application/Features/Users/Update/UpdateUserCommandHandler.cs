using AutoMapper;
using CSharpFunctionalExtensions;
using UserPhoneTest.Application.Abstractions;
using UserPhoneTest.Application.Repositories;
using UserPhoneTest.Application.Services;

namespace UserPhoneTest.Application.Features.Users.Update;

internal sealed class UpdateUserCommandHandler(
    IUserRepository userRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateUserCommand, UnitResult<Error>>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<UnitResult<Error>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var foundUser = await _userRepository.GetByIdAsyncWithTracking(request.userId, cancellationToken);

        if (foundUser is null) return UnitResult.Failure(UserErrors.UserNotFound);

        _mapper.Map(request.Data, foundUser);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return UnitResult.Success<Error>();
    }
}