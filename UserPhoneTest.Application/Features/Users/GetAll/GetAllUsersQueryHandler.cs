using AutoMapper;
using CSharpFunctionalExtensions;
using UserPhoneTest.Application.Abstractions;
using UserPhoneTest.Application.Contracts.Users;
using UserPhoneTest.Application.Repositories;

namespace UserPhoneTest.Application.Features.Users.GetAll;

internal sealed class GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper) 
    : IQueryHandler<GetAllUsersQuery, Result<List<UserResponse>>>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<Result<List<UserResponse>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync(cancellationToken);
        var mappedUsers = _mapper.Map<List<UserResponse>>(users);

        return Result.Success(mappedUsers);
    }
}
