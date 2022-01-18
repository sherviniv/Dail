using Dail.Application.Features.Activities.Models;
using MediatR;

namespace Dail.Application.Features.Activities.Queries.GetUserActivities;
public class GetUserActivitiesQuery : IRequest<IList<ActivityViewModel>>
{
}