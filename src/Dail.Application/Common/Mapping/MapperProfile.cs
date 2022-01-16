using AutoMapper;
using Dail.Application.Common.Models.DataTransferObjects;
using Dail.Application.Common.Models.ViewModels;
using Dail.Domain.Entities;

namespace Dail.Application.Common.Mapping;
public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<ApplicationUser, UserDTO>().ReverseMap();
        CreateMap<ApplicationUser, UserVM>().ReverseMap();
    }
}