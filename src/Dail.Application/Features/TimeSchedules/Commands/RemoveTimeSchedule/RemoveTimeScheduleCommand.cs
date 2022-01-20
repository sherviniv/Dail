using MediatR;

namespace Dail.Application.Features.Activities.Commands.RemoveActivity;
public class RemoveTimeScheduleCommand : IRequest<Unit>
{
    public int Id { get; set; }
}