﻿using Dail.Application.Features.Activities.Commands.AddActivity;
using Dail.Application.Features.Activities.Models;
using Dail.Application.Features.Activities.Queries.GetUserActivities;
using Dail.Application.Features.ActivityTimes.Commands.ModifyActivityTime;
using Dail.Application.Features.ActivityTimes.Commands.RemoveActivityTime;
using Dail.Domain.Constants;
using Dail.WebUI.Base;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dail.WebUI.Controllers;

[Authorize(Roles = SystemRoles.DailUser)]
public class ActivitiesController : ApiController
{
    private readonly ISender _mediatr;

    public ActivitiesController(ISender mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpGet("[action]")]
    public async Task<IList<ActivityViewModel>> GetActivities()
    => await _mediatr.Send(new GetUserActivitiesQuery());

    [HttpPost("[action]")]
    public async Task<int> Add(AddActivityCommand command)
        => await _mediatr.Send(command);

    [HttpPut("[action]")]
    public async Task<int> Modfiy(ModifyActivityTimeCommand command)
        => await _mediatr.Send(command);

    [HttpDelete("[action]")]
    public async Task<Unit> Remove(RemoveActivityTimeCommand command)
        => await _mediatr.Send(command);
}