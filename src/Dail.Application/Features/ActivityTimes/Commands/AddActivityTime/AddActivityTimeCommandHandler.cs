using AutoMapper;
using Dail.Application.Common.Interfaces;
using Dail.Domain.Entities;
using MediatR;

namespace Dail.Application.Features.ActivityTimes.Commands.AddActivityTime;

public class AddActivityTimeCommandHandler : IRequestHandler<AddActivityTimeCommand, int>
{
    private readonly IDailContext _context;
    private readonly IMapper _mapper;

    public AddActivityTimeCommandHandler(
        IDailContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Add new activity time to database
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> Handle(AddActivityTimeCommand request, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<ActivityTime>(request);
        _context.ActivityTimes.Add(model);
        await _context.SaveChangesAsync();
        return model.Id;
    }
}