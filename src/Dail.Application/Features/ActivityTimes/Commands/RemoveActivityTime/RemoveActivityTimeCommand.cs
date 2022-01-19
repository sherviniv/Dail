using MediatR;

namespace Dail.Application.Features.ActivityTimes.Commands.RemoveActivityTime;
public class RemoveActivityTimeCommand : IRequest<Unit>
{
    public int Id { get; set; }
}