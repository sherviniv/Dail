using MediatR;

namespace Dail.Application.Features.ActivityTimes.Commands.AddActivityTime;
public class AddActivityTimeCommand : IRequest<int>
{
    public DayOfWeek Day { get; set; }
    public string Title { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public int TimeScheduleId { get; set; }
}