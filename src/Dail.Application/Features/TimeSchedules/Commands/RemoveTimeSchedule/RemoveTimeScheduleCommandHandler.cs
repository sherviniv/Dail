using AutoMapper;
using Dail.Application.Common.Constants;
using Dail.Application.Common.Exceptions;
using Dail.Application.Common.Interfaces;
using Dail.Application.Common.Localization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Dail.Application.Features.TimeSchedules.Commands.RemoveTimeSchedule;
public class RemoveTimeScheduleCommandHandler : IRequestHandler<RemoveTimeScheduleCommand, Unit>
{
    private readonly IDailContext _context;
    private readonly ICurrentUserService _currentUserService;
    private readonly IStringLocalizer<MessagesLocalizer> _localizer;

    public RemoveTimeScheduleCommandHandler(
        IDailContext context,
        IStringLocalizer<MessagesLocalizer> localizer,
        ICurrentUserService currentUserService)
    {
        _context = context;
        _localizer = localizer;
        _currentUserService = currentUserService;
    }

    public async Task<Unit> Handle(RemoveTimeScheduleCommand request, CancellationToken cancellationToken)
    {
        var model = await _context.TimeSchedules
            .FirstOrDefaultAsync(c => c.Id == request.Id && c.CreatedBy == _currentUserService.UserId);

        if (model == null)
        {
            throw new DailException(MessageCodes.NotFound,
                   _localizer.GetString(MessageCodes.NotFound)?.Value ?? "", System.Net.HttpStatusCode.NotFound);
        }

        _context.TimeSchedules.Remove(model);
        await _context.SaveChangesAsync();
        return Unit.Value;
    }
}