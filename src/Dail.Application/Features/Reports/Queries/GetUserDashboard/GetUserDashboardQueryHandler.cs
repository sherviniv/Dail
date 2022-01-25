using Dail.Application.Common.Interfaces;
using Dail.Application.Features.Reports.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dail.Application.Features.Reports.Queries.GetUserDashboard;
public class GetUserDashboardQueryHandler : IRequestHandler<GetUserDashboardQuery, UserDashboardViewModel>
{
    private readonly IDailContext _context;
    private readonly ICurrentUserService _currentUserService;

    public GetUserDashboardQueryHandler(
        IDailContext context,
        ICurrentUserService currentUserService)
    {
        _context = context;
        _currentUserService = currentUserService;
    }


    public async Task<UserDashboardViewModel> Handle(GetUserDashboardQuery request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId;
        UserDashboardViewModel vm = new();
        var activities = await _context.Activities.Where(c => c.CreatedBy == userId).ToListAsync();
        vm.TotalTimeSchedules = await _context.TimeSchedules.CountAsync(c => c.CreatedBy == userId);
        vm.TotalActivities = activities.Count;
        vm.AssignedWorksCount = activities.Count(c=> c.ActivityTimeId != null);
        vm.UnAssignedWorksCount = activities.Count(c=> c.ActivityTimeId == null);
        vm.RecentWorks = activities.Select(c => c.Title).ToList();
        return vm;
    }
}