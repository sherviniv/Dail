using Dail.Application.Features.TimeSchedules.Models;
using MediatR;

namespace Dail.Application.Features.TimeSchedules.Queries.GetTimeSchedule;
public class GetTimeScheduleQuery : IRequest<TimeScheduleViewModel>
{
    public int Id { get; set; }

    public GetTimeScheduleQuery(int id)
    {
        Id = id;
    }
}