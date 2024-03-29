﻿using Dail.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dail.Application.Common.Interfaces;

public interface IDailContext
{
    DbSet<Activity> Activities { get; set; }
    DbSet<ActivityTime> ActivityTimes { get; set; }
    DbSet<TimeSchedule> TimeSchedules { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}