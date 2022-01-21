using Dail.Application.Features.ActivityTimes.Commands.AddActivityTime;
using Dail.Application.Features.ActivityTimes.Commands.ModifyActivityTime;
using Dail.Application.Features.ActivityTimes.Commands.RemoveActivityTime;
using Dail.Domain.Constants;
using Dail.WebUI.Base;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dail.WebUI.Controllers;

[Authorize(Roles = SystemRoles.DailUser)]
public class ActivityTimesController : ApiController
{
    private readonly ISender _mediatr;

    public ActivityTimesController(ISender mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpPost("[action]")]
    public async Task<int> Add(AddActivityTimeCommand command)
        => await _mediatr.Send(command);

    [HttpPut]
    public async Task<int> Modfiy(ModifyActivityTimeCommand command)
        => await _mediatr.Send(command);

    [HttpDelete]
    public async Task<Unit> Remove(RemoveActivityTimeCommand command)
        => await _mediatr.Send(command);
}