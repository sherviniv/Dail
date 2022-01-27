using Dail.Application.Features.TimeSchedules.Commands.AddTimeSchedule;
using Dail.Application.Features.TimeSchedules.Commands.ModifyTimeSchedule;
using Dail.Application.Features.TimeSchedules.Commands.RemoveTimeSchedule;
using Dail.Application.Features.TimeSchedules.Models;
using Dail.Application.Features.TimeSchedules.Queries.GetTimeSchedule;
using Dail.Application.Features.TimeSchedules.Queries.GetTimeScheduleById;
using Dail.Application.Features.TimeSchedules.Queries.GetTimeScheduleList;
using Dail.Domain.Constants;
using Dail.WebUI.Base;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dail.WebUI.Controllers;

[Authorize(Roles = SystemRoles.DailUser)]
public class TimeSchedulesController : ApiController
{
    private readonly ISender _mediatr;

    public TimeSchedulesController(ISender mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpGet("[action]")]
    public async Task<TimeScheduleViewModel> GetTimeSchedule(GetTimeScheduleQuery query)
       => await _mediatr.Send(query);

    [HttpGet("[action]")]
    public async Task<TimeScheduleInfoViewModel> GetById(int id)
       => await _mediatr.Send(new GetTimeScheduleByIdQuery(id));

    [HttpGet("[action]")]
    public async Task<IList<TimeScheduleInfoViewModel>> GetTimeScheduleList()
        => await _mediatr.Send(new GetTimeScheduleListQuery());

    [HttpPost("[action]")]
    public async Task<int> Add(AddTimeScheduleCommand command)
        => await _mediatr.Send(command);

    [HttpPut("[action]")]
    public async Task<int> Modfiy(ModifyTimeScheduleCommand command)
        => await _mediatr.Send(command);

    [HttpDelete("[action]")]
    public async Task<Unit> Remove(RemoveTimeScheduleCommand command)
        => await _mediatr.Send(command);
}