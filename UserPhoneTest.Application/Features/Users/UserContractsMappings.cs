using AutoMapper;
using UserPhoneTest.Application.Contracts.Users;
using UserPhoneTest.Domain.Modules.Users;

namespace UserPhoneTest.Application.Features.Users;

public class UserContractsMappings : Profile
{
    public UserContractsMappings()
    {
        CreateMap<User, UserResponse>();

        CreateMap<CreateUserRequest, User>();

        CreateMap<UpdateUserRequest, User>();

        CreateMap<User, UserDetailedResponse>();
    }
}
