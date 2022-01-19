﻿using AutoMapper;
using Dail.Application.Common.Constants;
using Dail.Application.Common.Exceptions;
using Dail.Application.Common.Interfaces;
using Dail.Application.Common.Localization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Dail.Application.Features.ActivityTimes.Commands.ModifyActivityTime;
public class ModifyActivityTimeCommandHandler : IRequestHandler<ModifyActivityTimeCommand, int>
{
    private readonly IDailContext _context;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;
    private readonly IStringLocalizer<MessagesLocalizer> _localizer;

    public ModifyActivityTimeCommandHandler(
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
    public async Task<int> Handle(ModifyActivityTimeCommand request, CancellationToken cancellationToken)
    {
        var model = await _context.ActivityTimes.FirstOrDefaultAsync(c=> c.Id == request.Id);

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