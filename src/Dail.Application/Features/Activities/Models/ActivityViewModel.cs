namespace Dail.Application.Features.Activities.Models;

public class ActivityViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public string Color { get; set; } = "#ffffff";
    public DateTime Created { get; set; }
    public DateTime? LastModified { get; set; }
}