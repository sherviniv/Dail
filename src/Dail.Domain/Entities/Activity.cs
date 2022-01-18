using System.ComponentModel.DataAnnotations;

namespace Dail.Domain.Entities;

public class Activity
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    [MaxLength(512)]
    public string Description { get; set; }

    /// <summary>
    /// Hex format
    /// </summary>
    [MaxLength(7)]
    public string Color { get; set; }
    public DayOfWeek Day { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
}
