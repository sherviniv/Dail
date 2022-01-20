using Dail.Application.Features.Activities.Models;
using MediatR;

namespace Dail.Application.Features.Activities.Queries.GetTimeSchedule;
public class GetTimeScheduleQuery : IRequest<IList<ActivityViewModel>>
{
}