﻿using MediatR;

namespace Dail.Application.Features.Activities.Commands.ModifyActivity;
public class ModifyActivityCommand : IRequest<int>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
    public DayOfWeek Day { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
}