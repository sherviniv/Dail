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
        var acitvity = await _context.Activities.FirstOrDefaultAsync(c=> c.Id == request.ActivityId);

        if(acitvity != null)
        {
            acitvity.ActivityTimeId = request.ActivityTimeId;
        }

        await _context.SaveChangesAsync();
        return Unit.Value;
    }
}