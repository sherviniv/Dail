using AutoMapper;
using Dail.Application.Common.Interfaces;
using Dail.Domain.Entities;
using MediatR;

namespace Dail.Application.Features.TimeSchedules.Commands.AddTimeSchedule;
public class AddTimeScheduleCommandHandler : IRequestHandler<AddTimeScheduleCommand, int>
{
    private readonly IDailContext _context;
    private readonly IMapper _mapper;

    public AddTimeScheduleCommandHandler(
        IDailContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<int> Handle(AddTimeScheduleCommand request, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<TimeSchedule>(request);
        _context.TimeSchedules.Add(model);
        await _context.SaveChangesAsync();
        return model.Id;
    }
}