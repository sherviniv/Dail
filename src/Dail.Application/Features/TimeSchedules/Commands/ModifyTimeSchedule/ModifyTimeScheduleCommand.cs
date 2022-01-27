using MediatR;

namespace Dail.Application.Features.TimeSchedules.Commands.ModifyTimeSchedule;
public class ModifyTimeScheduleCommand : IRequest<int>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
}