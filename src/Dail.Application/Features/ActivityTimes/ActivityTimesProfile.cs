using AutoMapper;
using Dail.Application.Features.ActivityTimes.Commands.AddActivityTime;
using Dail.Application.Features.ActivityTimes.Commands.ModifyActivityTime;
using Dail.Domain.Entities;

namespace Dail.Application.Features.ActivityTimes;
internal class ActivityTimesProfile : Profile
{
    public ActivityTimesProfile()
    {
        CreateMap<ActivityTime, AddActivityTimeCommand>().ReverseMap();
        CreateMap<ActivityTime, ModifyActivityTimeCommand>().ReverseMap();
    }
}