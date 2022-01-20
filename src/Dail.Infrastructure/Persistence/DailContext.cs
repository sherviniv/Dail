using Dail.Application.Common.Interfaces;
using Dail.Domain.Common;
using Dail.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Dail.Infrastructure.Persistence;

internal class DailContext : IdentityDbContext<ApplicationUser>, IDailContext
{
    private readonly ICurrentUserService _currentUserService;

    public DailContext(
        DbContextOptions<DailContext> options,
        ICurrentUserService currentUserService) : base(options)
    {
        _currentUserService = currentUserService;
    }

    public DbSet<TimeSchedule> TimeSchedules { get; set; }
    public DbSet<ActivityTime> ActivityTimes { get; set; }
    public DbSet<Activity> Activities { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            DateTime now = DateTime.UtcNow;
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = _currentUserService.UserId;
                    entry.Entity.Created = now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedBy = _currentUserService.UserId;
                    entry.Entity.LastModified = now;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("Dail");
    }
}