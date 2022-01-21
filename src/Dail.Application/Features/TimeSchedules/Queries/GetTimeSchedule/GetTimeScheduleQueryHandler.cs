using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dail.Application.Common.Constants;
using Dail.Application.Common.Exceptions;
using Dail.Application.Common.Interfaces;
using Dail.Application.Common.Localization;
using Dail.Application.Features.Activities.Models;
using Dail.Application.Features.ActivityTimes.Models;
using Dail.Application.Features.TimeSchedules.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Dail.Application.Features.TimeSchedules.Queries.GetTimeSchedule;
public class GetTimeScheduleQueryHandler : IRequestHandler<GetTimeScheduleQuery, TimeScheduleViewModel>
{
    private readonly IDailContext _context;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;
    private readonly IStringLocalizer<MessagesLocalizer> _localizer;

    public GetTimeScheduleQueryHandler(
        IDailContext context,
        IMapper mapper,
        ICurrentUserService currentUserService,
        IStringLocalizer<MessagesLocalizer> localizer)
    {
        _context = context;
        _mapper = mapper;
        _currentUserService = currentUserService;
        _localizer = localizer;
    }

    public async Task<TimeScheduleViewModel> Handle(GetTimeScheduleQuery request, CancellationToken cancellationToken)
    {
        var scheduleModel = await _context.TimeSchedules
            .FirstOrDefaultAsync(c => c.CreatedBy == _currentUserService.UserId && c.Id == request.Id);

        if (scheduleModel == null)
        {
            throw new DailException(MessageCodes.NotFound,
                   _localizer.GetString(MessageCodes.NotFound)?.Value ?? "", System.Net.HttpStatusCode.NotFound);
        }

        TimeScheduleViewModel vm = 
            new(scheduleModel.Id, scheduleModel!.Title, scheduleModel.Description);

        vm.UnAssignedActivities = await _context.Activities
            .Where(c => c.CreatedBy == _currentUserService.UserId && c.ActivityTimeId == null)
            .AsNoTracking()     
            .ProjectTo<ActivityViewModel>(_mapper.ConfigurationProvider)
            .ToListAsync();

        vm.ActivityTimes = await _context.ActivityTimes
            .Where(c => c.TimeScheduleId == vm.Id)
            .Include(c => c.Activities)
            .AsNoTracking()
            .ProjectTo<ActivityTimeViewModel>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return vm;
    }
}