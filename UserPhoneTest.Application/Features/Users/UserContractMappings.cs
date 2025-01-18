using AutoMapper;
using UserPhoneTest.Application.Contracts.Users;
using UserPhoneTest.Domain.Modules.Users;

namespace UserPhoneTest.Application.Features.Users;

public class UserContractMappings : Profile
{
    public UserContractMappings()
    {
        CreateMap<User, UserResponse>();
    }
}
