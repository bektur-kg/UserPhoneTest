using AutoMapper;
using CSharpFunctionalExtensions;
using UserPhoneTest.Application.Abstractions;
using UserPhoneTest.Application.Contracts.Users;
using UserPhoneTest.Application.Repositories;

namespace UserPhoneTest.Application.Features.Users.GetAll;

internal sealed class GetUsersQueryHandler(IUserRepository userRepository, IMapper mapper) 
    : IQueryHandler<GetUsersQuery, Result<List<UserResponse>>>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<Result<List<UserResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync(cancellationToken);
        var mappedUsers = _mapper.Map<List<UserResponse>>(users);

        return Result.Success(mappedUsers);
    }
}
