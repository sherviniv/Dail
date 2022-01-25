namespace Dail.Application.Features.Reports.Models;
public class UserDashboardViewModel
{
    public int TotalTimeSchedules { get; set; }
    public int TotalActivities { get; set; }
    public int AssignedWorksCount { get; set; }
    public int UnAssignedWorksCount { get; set; }
    public List<string> RecentWorks { get; set; }
}