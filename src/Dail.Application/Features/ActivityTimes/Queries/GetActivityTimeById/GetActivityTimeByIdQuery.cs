using Dail.Application.Features.Activities.Models;
using Dail.Application.Features.ActivityTimes.Models;
using MediatR;

namespace Dail.Application.Features.ActivityTimes.Queries.GetActivityTimeById;
public class GetActivityTimeByIdQuery : IRequest<ActivityTimeInfoViewModel>
{
    public int Id { get; set; }

    public GetActivityTimeByIdQuery()
    {
    }

    public GetActivityTimeByIdQuery(int id)
    {
        Id = id;
    }
}