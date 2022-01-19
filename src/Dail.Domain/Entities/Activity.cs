using Dail.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Dail.Domain.Entities;
public class Activity : AuditableEntity
{
    public int Id { get; set; }

    [Required]
    [MaxLength(256)]
    public string Title { get; set; }

    [MaxLength(1024)]
    public string Description { get; set; }

    /// <summary>
    /// Hex format
    /// </summary>
    [MaxLength(7)]
    public string Color { get; set; }

    public int? ActivityTimeId { get; set; }
    public ActivityTime ActivityTime { get; set; }
}
