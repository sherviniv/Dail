using MediatR;

namespace Dail.Application.Features.ActivityTimes.Commands.ModifyActivityTime;
public class ModifyActivityTimeCommand : IRequest<int>
{
    public int Id { get; set; }
    public DayOfWeek Day { get; set; }
    public string Title { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
}