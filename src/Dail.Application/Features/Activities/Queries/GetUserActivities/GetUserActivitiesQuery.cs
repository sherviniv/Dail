using Dail.Application.Features.Activities.Models;
using MediatR;
using System.Collections.Generic;

namespace Dail.Application.Features.Activities.Queries.GetUserActivities;
public class GetUserActivitiesQuery : IRequest<IList<ActivityViewModel>>
{
    public int Id { get; set; }

    public GetUserActivitiesQuery(int id)
    {
        Id = id;
    }
}