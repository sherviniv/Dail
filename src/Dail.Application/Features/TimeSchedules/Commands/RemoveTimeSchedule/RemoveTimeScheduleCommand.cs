using MediatR;

namespace Dail.Application.Features.TimeSchedules.Commands.RemoveTimeSchedule;
public class RemoveTimeScheduleCommand : IRequest<Unit>
{
    public int Id { get; set; }
}