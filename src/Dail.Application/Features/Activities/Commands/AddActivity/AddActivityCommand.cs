using MediatR;

namespace Dail.Application.Features.Activities.Commands.AddActivity;
public class AddActivityCommand : IRequest<int>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
}