using AutoMapper;
using Dail.Application.Features.Activities.Commands.AddActivity;
using Dail.Application.Features.Activities.Commands.ModifyActivity;
using Dail.Application.Features.Activities.Models;
using Dail.Domain.Entities;

namespace Dail.Application.Features.Activities;
internal class ActivityProfile : Profile
{
    public ActivityProfile()
    {
        CreateMap<Activity, AddActivityCommand>().ReverseMap();
        CreateMap<Activity, ModifyActivityCommand>().ReverseMap();
        CreateMap<Activity, ActivityViewModel>().ReverseMap();
    }
}