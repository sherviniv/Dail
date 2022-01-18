using MediatR;

namespace Dail.Application.Features.Activities.Commands.RemoveActivity;
public class RemoveActivityCommand : IRequest<Unit>
{
    public int Id { get; set; }
}