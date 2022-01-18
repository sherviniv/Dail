using MediatR;

namespace Dail.Application.Features.Activities.Commands.AddActivity;
public class RemoveActivityCommand : IRequest<Unit>
{
    public int Id { get; set; }
}