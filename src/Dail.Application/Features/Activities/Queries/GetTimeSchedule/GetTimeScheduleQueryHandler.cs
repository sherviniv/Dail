using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dail.Application.Common.Interfaces;
using Dail.Application.Features.Activities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dail.Application.Features.Activities.Queries.GetTimeSchedule;
public class GetTimeScheduleQueryHandler : IRequestHandler<GetTimeScheduleQuery, IList<ActivityViewModel>>
{
    private readonly IDailContext _context;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;

    public GetTimeScheduleQueryHandler(
        IDailContext context,
        IMapper mapper,
        ICurrentUserService currentUserService)
    {
        _context = context;
        _mapper = mapper;
        _currentUserService = currentUserService;
    }

    public async Task<IList<ActivityViewModel>> Handle(GetTimeScheduleQuery request, CancellationToken cancellationToken)
    {
        var vm = await _context.Activities.Where(c => c.CreatedBy == _currentUserService.UserId)
            .AsNoTracking().ProjectTo<ActivityViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        return vm;
    }
}