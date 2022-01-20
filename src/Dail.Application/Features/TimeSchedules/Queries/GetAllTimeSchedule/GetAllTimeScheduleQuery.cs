﻿using Dail.Application.Features.TimeSchedules.Models;
using MediatR;

namespace Dail.Application.Features.TimeSchedules.Queries.GetAllTimeSchedule;
public class GetAllTimeScheduleQuery : IRequest<IList<TimeScheduleInfoViewModel>>
{
}