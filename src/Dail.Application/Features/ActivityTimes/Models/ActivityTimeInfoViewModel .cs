namespace Dail.Application.Features.ActivityTimes.Models;
public class ActivityTimeInfoViewModel
{
    public int Id { get; set; }
    public DayOfWeek Day { get; set; }
    public string Title { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public string TimeSchedulesTitle { get; set; }
    public int TimeScheduleId { get; set; }
    public DateTime Created { get; set; }
    public DateTime? LastModified { get; set; }
}