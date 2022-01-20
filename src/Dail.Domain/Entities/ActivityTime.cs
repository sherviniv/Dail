using Dail.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Dail.Domain.Entities;
public class ActivityTime : AuditableEntity
{
    public int Id { get; set; }
    public DayOfWeek Day { get; set; }

    [MaxLength(256)]
    public string Title { get; set; }

    [MaxLength(11)]
    public string StartTime { get; set; }
    [MaxLength(11)]
    public string EndTime { get; set; }

    public int TimeScheduleId { get; set; }
    public TimeSchedule TimeSchedule { get; set; }
}