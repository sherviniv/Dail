using AutoMapper;
using Dail.Application.Features.TimeSchedules.Commands.AddTimeSchedule;
using Dail.Application.Features.TimeSchedules.Commands.ModifyTimeSchedule;
using Dail.Domain.Entities;

namespace Dail.Application.Features.TimeSchedules;
internal class TimeScheduleProfile : Profile
{
    public TimeScheduleProfile()
    {
        CreateMap<TimeSchedule, AddTimeScheduleCommand>().ReverseMap();
        CreateMap<TimeSchedule, ModifyTimeScheduleCommand>().ReverseMap();
    }
}