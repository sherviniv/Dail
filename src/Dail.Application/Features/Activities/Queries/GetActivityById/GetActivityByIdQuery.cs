using Dail.Application.Features.Activities.Models;
using MediatR;

namespace Dail.Application.Features.Activities.Queries.GetActivityById;
public class GetActivityByIdQuery : IRequest<ActivityViewModel>
{
    public int Id { get; set; }

    public GetActivityByIdQuery()
    {
    }

    public GetActivityByIdQuery(int id)
    {
        Id = id;
    }
}