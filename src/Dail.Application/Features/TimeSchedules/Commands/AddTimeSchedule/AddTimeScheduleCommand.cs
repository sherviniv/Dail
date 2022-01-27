using MediatR;

namespace Dail.Application.Features.TimeSchedules.Commands.AddTimeSchedule;
public class AddTimeScheduleCommand : IRequest<int>
{
    public string Title { get; set; }
    public string? Description { get; set; }
}