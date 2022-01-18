using Dail.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dail.Application.Common.Interfaces;

public interface IDailContext
{
    DbSet<Activity> Activities { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}