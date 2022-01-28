using AutoMapper;
using Dail.Application.Common.Constants;
using Dail.Application.Common.Exceptions;
using Dail.Application.Common.Interfaces;
using Dail.Application.Common.Localization;
using Dail.Application.Features.Activities.Models;
using Dail.Application.Features.Activities.Queries.GetActivityById;
using Dail.Application.Features.ActivityTimes.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Dail.Application.Features.ActivityTimes.Queries.GetActivityTimeById;
public class GetActivityTimeByIdQueryHandler : IRequestHandler<GetActivityTimeByIdQuery, ActivityTimeInfoViewModel>
{
    private readonly IDailContext _context;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;
    private readonly IStringLocalizer<MessagesLocalizer> _localizer;

    public GetActivityTimeByIdQueryHandler(
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

    public async Task<ActivityTimeInfoViewModel> Handle(GetActivityTimeByIdQuery request, CancellationToken cancellationToken)
    {
        var model = await _context.ActivityTimes.AsNoTracking()
                              .FirstOrDefaultAsync(c => c.CreatedBy == _currentUserService.UserId && c.Id == request.Id);

        if (model == null)
        {
            throw new DailException(MessageCodes.NotFound,
              _localizer.GetString(MessageCodes.NotFound)?.Value ?? "", System.Net.HttpStatusCode.NotFound);
        }

        var vm = _mapper.Map<ActivityTimeInfoViewModel>(model);
        return vm;
    }
}