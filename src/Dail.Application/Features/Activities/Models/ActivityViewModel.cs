﻿namespace Dail.Application.Features.Activities.Models;

public class ActivityViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
    public DayOfWeek Day { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
}