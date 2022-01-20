using Dail.Application.Features.ActivityTimes.Models;

namespace Dail.Application.Features.Activities.Models;
public class TimeScheduleViewModel
{
    public string Title { get; set; }
    public List<ActivityTimeViewModel> ActivityTimes { get; set; }
}