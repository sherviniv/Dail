using Dail.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Dail.Domain.Entities;

public class TimeSchedule : AuditableEntity
{
    public int Id { get; set; }

    [Required]
    [MaxLength(128)]
    public string Title { get; set; }

    [MaxLength(128)]
    public string Description { get; set; }
}
