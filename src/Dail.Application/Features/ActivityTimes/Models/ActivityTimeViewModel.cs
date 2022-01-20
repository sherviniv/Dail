using Dail.Application.Features.Activities.Models;

namespace Dail.Application.Features.ActivityTimes.Models;
public class ActivityTimeViewModel
{
    public int Id { get; set; }
    public DayOfWeek Day { get; set; }
    public string Title { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public List<ActivityViewModel> Activities { get; set; }
}