using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dail.Application.Common.Interfaces;
using Dail.Application.Features.ActivityTimes.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dail.Application.Features.ActivityTimes.Queries.GetActivityTimesList;
public class GetActivityTimesListQueryHandler : IRequestHandler<GetActivityTimesListQuery, IList<ActivityTimeInfoViewModel>>
{
    private readonly IDailContext _context;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;

    public GetActivityTimesListQueryHandler(
        IDailContext context,
        IMapper mapper,
        ICurrentUserService currentUserService)
    {
        _context = context;
        _mapper = mapper;
        _currentUserService = currentUserService;
    }

    public async Task<IList<ActivityTimeInfoViewModel>> Handle(GetActivityTimesListQuery request, CancellationToken cancellationToken)
    {
        var vm = await _context.ActivityTimes.Where(c => c.CreatedBy == _currentUserService.UserId)
            .Include(c => c.TimeSchedule).AsNoTracking()
            .ProjectTo<ActivityTimeInfoViewModel>(_mapper.ConfigurationProvider).ToListAsync();

        return vm;
    }
}