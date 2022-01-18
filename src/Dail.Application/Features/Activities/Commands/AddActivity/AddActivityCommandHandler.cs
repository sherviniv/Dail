using AutoMapper;
using Dail.Application.Common.Interfaces;
using Dail.Domain.Entities;
using MediatR;

namespace Dail.Application.Features.Activities.Commands.AddActivity;

public class AddActivityCommandHandler : IRequestHandler<AddActivityCommand, int>
{
    private readonly IDailContext _context;
    private readonly IMapper _mapper;

    public AddActivityCommandHandler(
        IDailContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Add new activiy to database
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> Handle(AddActivityCommand request, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<Activity>(request);
        _context.Activities.Add(model);
        await _context.SaveChangesAsync();
        return model.Id;
    }
}