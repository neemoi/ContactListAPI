using Application.DtoModels;
using AutoMapper;
using Domain.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ContactDto, Contact>()
           .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<Contact, ContactDto>();
    }
}