using AutoMapper;
using UserPhoneTest.Application.Contracts.Phones;
using UserPhoneTest.Domain.Modules.Phones;

namespace UserPhoneTest.Application.Features.Phones;

public class PhoneContractsMappings : Profile
{
    public PhoneContractsMappings()
    {
        CreateMap<Phone, PhoneResponse>();
    }
}
