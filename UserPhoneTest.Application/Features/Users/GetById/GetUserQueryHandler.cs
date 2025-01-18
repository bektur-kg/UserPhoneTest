using AutoMapper;
using CSharpFunctionalExtensions;
using UserPhoneTest.Application.Abstractions;
using UserPhoneTest.Application.Contracts.Users;
using UserPhoneTest.Application.Repositories;

namespace UserPhoneTest.Application.Features.Users.GetById;

internal sealed class GetUserQueryHandler(IUserRepository userRepository, IMapper mapper)
    : IQueryHandler<GetUserQuery, Result<UserResponse, Error>>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<Result<UserResponse, Error>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var foundUser = await _userRepository.GetByIdAsyncWithInclude();
    }
}
