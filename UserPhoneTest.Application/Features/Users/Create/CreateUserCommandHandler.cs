using AutoMapper;
using CSharpFunctionalExtensions;
using UserPhoneTest.Application.Abstractions;
using UserPhoneTest.Application.Repositories;
using UserPhoneTest.Application.Services;
using UserPhoneTest.Domain.Modules.Users;

namespace UserPhoneTest.Application.Features.Users.Create;

internal sealed class CreateUserCommandHandler(
    IUserRepository userRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateUserCommand, UnitResult<Error>>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<UnitResult<Error>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var doesUserExist = await _userRepository.DoesUserExistAsync(request.Data.Email, cancellationToken);

        if (doesUserExist) return UnitResult.Failure(UserErrors.UserExists);

        var mappedUser = _mapper.Map<User>(request.Data);

        _userRepository.Add(mappedUser);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return UnitResult.Success<Error>();
    }
}
