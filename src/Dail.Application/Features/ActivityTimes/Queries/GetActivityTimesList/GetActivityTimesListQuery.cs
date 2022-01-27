using Dail.Application.Features.ActivityTimes.Models;
using MediatR;

namespace Dail.Application.Features.ActivityTimes.Queries.GetActivityTimesList;
public class GetActivityTimesListQuery : IRequest<IList<ActivityTimeInfoViewModel>>
{
}