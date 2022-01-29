using Dail.Application.Features.Activities.Models;
using MediatR;

namespace Dail.Application.Features.Activities.Commands.AssignActivity;
public class AssignActivityCommand : IRequest<Unit>
{
    public int ActivityId { get; set; }
    public int? ActivityTimeId { get; set; }
}