using Dail.Application.Features.Activities.Models;
using MediatR;

namespace Dail.Application.Features.Activities.Commands.AssignActivity;
public class AssignActivityCommand : IRequest<Unit>
{
    public List<AssignActivityDTO> Assigns { get; set; }
}