using AutoMapper;
using Dail.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dail.Application.Features.Activities.Commands.AssignActivity;
public class AssignActivityCommandHandler : IRequestHandler<AssignActivityCommand, Unit>
{
    private readonly IDailContext _context;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;

    public AssignActivityCommandHandler(
        IDailContext context,
        IMapper mapper,
        ICurrentUserService currentUserService)
    {
        _context = context;
        _mapper = mapper;
        _currentUserService = currentUserService;
    }

    /// <summary>
    /// Assign activity to time activity
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Unit> Handle(AssignActivityCommand request, CancellationToken cancellationToken)
    {
        //Get all selected activities
        var activitiesIds = request.Assigns.Select(c => c.ActivityId).ToList();
        var models = await _context.Activities.Where(c =>
        c.CreatedBy == _currentUserService.UserId && activitiesIds.Contains(c.Id)).ToListAsync();

        //assign activities to selected times
        foreach (var activity in models)
        {
            int? timeId = request.Assigns
                .FirstOrDefault(c => c.ActivityId == activity.Id)!.ActivityTimeId;
            activity.ActivityTimeId = timeId;
        }

        await _context.SaveChangesAsync();
        return Unit.Value;
    }
}