using Dail.Application.Features.Activities.Models;
using Dail.Application.Features.ActivityTimes.Models;

namespace Dail.Application.Features.TimeSchedules.Models;
public class TimeScheduleViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<ActivityTimeViewModel> ActivityTimes { get; set; }
    public List<ActivityViewModel> UnAssignedActivities { get; set; }

    public TimeScheduleViewModel()
    {
    }

    public TimeScheduleViewModel(int id,string title, string description)
    {
        (Title, Description, Id) = (title, description, id);
    }
}