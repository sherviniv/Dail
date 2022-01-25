using Dail.Application.Features.Reports.Models;
using Dail.Application.Features.Reports.Queries.GetUserDashboard;
using Dail.Domain.Constants;
using Dail.WebUI.Base;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dail.WebUI.Controllers;

[Authorize(Roles = SystemRoles.DailUser)]
public class ReportsController : ApiController
{
    private readonly ISender _mediatr;

    public ReportsController(ISender mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpGet("[action]")]
    public async Task<UserDashboardViewModel> GetUserDashboard()
         => await _mediatr.Send(new GetUserDashboardQuery());
}