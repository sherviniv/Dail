using AutoMapper;
using Dail.Application.Features.ActivityTimes.Models;
using Dail.Application.Features.TimeSchedules.Commands.AddTimeSchedule;
using Dail.Application.Features.TimeSchedules.Commands.ModifyTimeSchedule;
using Dail.Application.Features.TimeSchedules.Models;
using Dail.Domain.Entities;

namespace Dail.Application.Features.TimeSchedules;
internal class TimeScheduleProfile : Profile
{
    public TimeScheduleProfile()
    {
        CreateMap<TimeSchedule, AddTimeScheduleCommand>().ReverseMap();
        CreateMap<TimeSchedule, ModifyTimeScheduleCommand>().ReverseMap();
        CreateMap<TimeSchedule, TimeScheduleInfoViewModel>().ReverseMap();

        CreateMap<ActivityTime, ActivityTimeViewModel>()
            .ForMember(c=> c.Activities,src => src.MapFrom(c=> c.Activities)).ReverseMap();
    }
}