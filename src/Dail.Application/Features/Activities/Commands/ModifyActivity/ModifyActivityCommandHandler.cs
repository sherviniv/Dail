using AutoMapper;
using Dail.Application.Common.Constants;
using Dail.Application.Common.Exceptions;
using Dail.Application.Common.Interfaces;
using Dail.Application.Common.Localization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Dail.Application.Features.Activities.Commands.ModifyActivity;
public class ModifyActivityCommandHandler : IRequestHandler<ModifyActivityCommand, int>
{
    private readonly IDailContext _context;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;
    private readonly IStringLocalizer<MessagesLocalizer> _localizer;

    public ModifyActivityCommandHandler(
        IDailContext context,
        IMapper mapper,
        IStringLocalizer<MessagesLocalizer> localizer,
        ICurrentUserService currentUserService)
    {
        _context = context;
        _mapper = mapper;
        _localizer = localizer;
        _currentUserService = currentUserService;
    }

    /// <summary>
    /// Modify selected activity
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> Handle(ModifyActivityCommand request, CancellationToken cancellationToken)
    {
        var model = await _context.Activities.FirstOrDefaultAsync();

        if (model == null)
        {
            throw new DailException(MessageCodes.NotFound,
                   _localizer.GetString(MessageCodes.NotFound)?.Value ?? "", System.Net.HttpStatusCode.NotFound);
        }
        //Each user has only access to their own Activities
        if (model.CreatedBy != _currentUserService.UserId)
        {
            throw new DailException(MessageCodes.AccessDenied,
                   _localizer.GetString(MessageCodes.AccessDenied)?.Value ?? "", System.Net.HttpStatusCode.Forbidden);
        }

        _mapper.Map(request, model);
        await _context.SaveChangesAsync();
        return model.Id;
    }
}