using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dail.Application.Common.Constants;
using Dail.Application.Common.Exceptions;
using Dail.Application.Common.Interfaces;
using Dail.Application.Common.Localization;
using Dail.Application.Features.TimeSchedules.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Dail.Application.Features.TimeSchedules.Queries.GetTimeScheduleById;
public class GetTimeScheduleByIdQueryHandler : IRequestHandler<GetTimeScheduleByIdQuery, TimeScheduleInfoViewModel>
{
    private readonly IDailContext _context;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;
    private readonly IStringLocalizer<MessagesLocalizer> _localizer;

    public GetTimeScheduleByIdQueryHandler(
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

    public async Task<TimeScheduleInfoViewModel> Handle(GetTimeScheduleByIdQuery request, CancellationToken cancellationToken)
    {
        var model = await _context.TimeSchedules.AsNoTracking()
                .FirstOrDefaultAsync(c => c.CreatedBy == _currentUserService.UserId && c.Id == request.Id);

        if (model == null)
        {
            throw new DailException(MessageCodes.NotFound,
              _localizer.GetString(MessageCodes.NotFound)?.Value ?? "", System.Net.HttpStatusCode.NotFound);
        }

        var vm = _mapper.Map<TimeScheduleInfoViewModel>(model);
        return vm;
    }
}