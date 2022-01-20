using Dail.Application.Features.Activities.Models;
using MediatR;

namespace Dail.Application.Features.TimeSchedules.Queries.GetAllTimeSchedule;
public class GetAllTimeScheduleQuery : IRequest<IList<ActivityViewModel>>
{
}