using Dail.Application.Features.Activities.Models;
using Dail.Application.Features.ActivityTimes.Models;

namespace Dail.Application.Features.TimeSchedules.Models;
public class TimeScheduleViewModel
{
    public string Title { get; set; }
    public string MyProperty { get; set; }
    public List<ActivityTimeViewModel> ActivityTimes { get; set; }
    public List<ActivityViewModel> UnAssignedActivities { get; set; }
}