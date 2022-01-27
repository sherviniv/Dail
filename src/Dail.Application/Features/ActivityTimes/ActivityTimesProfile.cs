using AutoMapper;
using Dail.Application.Features.ActivityTimes.Commands.AddActivityTime;
using Dail.Application.Features.ActivityTimes.Commands.ModifyActivityTime;
using Dail.Application.Features.ActivityTimes.Models;
using Dail.Domain.Entities;

namespace Dail.Application.Features.ActivityTimes;
internal class ActivityTimesProfile : Profile
{
    public ActivityTimesProfile()
    {
        CreateMap<ActivityTime, AddActivityTimeCommand>().ReverseMap();
        CreateMap<ActivityTime, ModifyActivityTimeCommand>().ReverseMap();
        CreateMap<ActivityTime, ActivityTimeInfoViewModel>()
            .ForMember(c=> c.TimeScheduleId, src=> src.MapFrom(c=> c.TimeScheduleId))
            .ForMember(c=> c.TimeSchedulesTitle, src=> src.MapFrom(c=> c.TimeSchedule.Title))
            .ReverseMap();
    }
}