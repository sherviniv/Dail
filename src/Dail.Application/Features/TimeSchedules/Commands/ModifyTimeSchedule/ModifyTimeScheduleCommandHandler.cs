using AutoMapper;
using Dail.Application.Common.Constants;
using Dail.Application.Common.Exceptions;
using Dail.Application.Common.Interfaces;
using Dail.Application.Common.Localization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Dail.Application.Features.TimeSchedules.Commands.ModifyTimeSchedule;
public class ModifyTimeScheduleCommandHandler : IRequestHandler<ModifyTimeScheduleCommand, int>
{
    private readonly IDailContext _context;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;
    private readonly IStringLocalizer<MessagesLocalizer> _localizer;

    public ModifyTimeScheduleCommandHandler(
        IDailContext context,
        IMapper mapper,
        IStringLocalizer<MessagesLocalizer> localizer,
        ICurrentUserService currentUserService)
    {
        _context = context;
        _mapper = mapper;
        _localizer = localizer;
        _currentUserService = currentUserService;
    }

    public async Task<int> Handle(ModifyTimeScheduleCommand request, CancellationToken cancellationToken)
    {
        var model = await _context.TimeSchedules.FirstOrDefaultAsync(c => c.Id == request.Id);

        if (model == null)
        {
            throw new DailException(MessageCodes.NotFound,
                   _localizer.GetString(MessageCodes.NotFound)?.Value ?? "", System.Net.HttpStatusCode.NotFound);
        }

        if (model.CreatedBy != _currentUserService.UserId)
        {
            throw new DailException(MessageCodes.AccessDenied,
                   _localizer.GetString(MessageCodes.AccessDenied)?.Value ?? "", System.Net.HttpStatusCode.Forbidden);
        }

        _mapper.Map(request, model);
        await _context.SaveChangesAsync();
        return model.Id;
    }
}