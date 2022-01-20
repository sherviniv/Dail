using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dail.Application.Common.Interfaces;
using Dail.Application.Features.Activities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dail.Application.Features.TimeSchedules.Queries.GetAllTimeSchedule;
public class GetAllTimeScheduleQueryHandler : IRequestHandler<GetAllTimeScheduleQuery, IList<ActivityViewModel>>
{
    private readonly IDailContext _context;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;

    public GetAllTimeScheduleQueryHandler(
        IDailContext context,
        IMapper mapper,
        ICurrentUserService currentUserService)
    {
        _context = context;
        _mapper = mapper;
        _currentUserService = currentUserService;
    }

    public async Task<IList<ActivityViewModel>> Handle(GetAllTimeScheduleQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}