using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dail.Application.Common.Interfaces;
using Dail.Application.Features.Activities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dail.Application.Features.Activities.Queries.GetUserActivities;
public class GetUserActivitiesQueryHandler : IRequestHandler<GetUserActivitiesQuery, IList<ActivityViewModel>>
{
    private readonly IDailContext _context;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;

    public GetUserActivitiesQueryHandler(
        IDailContext context,
        IMapper mapper,
        ICurrentUserService currentUserService)
    {
        _context = context;
        _mapper = mapper;
        _currentUserService = currentUserService;
    }


    /// <summary>
    /// Returns current user Activities
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IList<ActivityViewModel>> Handle(GetUserActivitiesQuery request, CancellationToken cancellationToken)
    {
        var vm = await _context.Activities.Where(c => c.CreatedBy == _currentUserService.UserId)
            .AsNoTracking().ProjectTo<ActivityViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        return vm;
    }
}