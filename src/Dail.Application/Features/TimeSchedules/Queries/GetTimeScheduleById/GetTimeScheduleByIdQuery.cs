using Dail.Application.Features.TimeSchedules.Models;
using MediatR;

namespace Dail.Application.Features.TimeSchedules.Queries.GetTimeScheduleById;
public class GetTimeScheduleByIdQuery : IRequest<TimeScheduleInfoViewModel>
{
    public int Id { get; set; }

    public GetTimeScheduleByIdQuery()
    {
    }

    public GetTimeScheduleByIdQuery(int id)
    {
        Id = id;
    }
}