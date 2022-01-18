using Dail.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Dail.Domain.Entities;

public class Activity : AuditableEntity
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    [MaxLength(1024)]
    public string Description { get; set; }

    /// <summary>
    /// Hex format
    /// </summary>
    [MaxLength(7)]
    public string Color { get; set; }
    public DayOfWeek Day { get; set; }

    [MaxLength(11)]
    public string StartTime { get; set; }
    [MaxLength(11)]
    public string EndTime { get; set; }
}
