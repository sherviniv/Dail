﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dail.Application.Common.Constants;
using Dail.Application.Common.Exceptions;
using Dail.Application.Common.Interfaces;
using Dail.Application.Common.Localization;
using Dail.Application.Common.Models.DataTransferObjects;
using Dail.Application.Common.Models.ViewModels;
using Dail.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Dail.Application.Services;
internal class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IJwtHandler _jwtHandler;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<MessagesLocalizer> _localizer;


    public IdentityService(
        UserManager<ApplicationUser> userManager,
        IJwtHandler jwtHandler,
        IMapper mapper,
        IStringLocalizer<MessagesLocalizer> localizer)
    {
        _userManager = userManager;
        _jwtHandler = jwtHandler;
        _mapper = mapper;
        _localizer = localizer;
    }

    public async Task<string> CreateUserAsync(UserDTO model)
    {
        var user = new ApplicationUser
        {
            UserName = model.UserName,
            Email = model.Email
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
            throw new ValidationException(result.Errors);

        return user.Id;
    }

    public async Task<string> DeleteUserAsync(string userId)
    {
        var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == userId);

        if (user != null)
        {
            await DeleteUserAsync(user);
        }

        return userId;
    }

    public async Task<bool> DeleteUserAsync(ApplicationUser user)
    {
        var result = await _userManager.DeleteAsync(user);
        if (!result.Succeeded)
            throw new ValidationException(result.Errors);

        return true;
    }

    public async Task<UserDTO> GetUserAsync(string userId)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

        if (user == null)
            throw new DailException(MessageCodes.NotFound,
                _localizer.GetString(MessageCodes.NotFound)?.Value ?? "", System.Net.HttpStatusCode.NotFound);

        return _mapper.Map<UserDTO>(user);
    }

    public async Task<string> GetUserNameAsync(string userId)
    {
        var user = await _userManager.Users.AsNoTracking().FirstAsync(u => u.Id == userId);
        return user.UserName;
    }

    public async Task<List<UserVM>> GetUsersAsync()
    {
        var users = await _userManager.Users
            .AsNoTracking()
            .ProjectTo<UserVM>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return users;
    }

    public async Task<string> LoginUserAsync(LoginDTO model)
    {
        var user = await _userManager.Users.SingleOrDefaultAsync(u => u.UserName == model.Username);

        if (user == null)
            throw new DailException(MessageCodes.InvalidCredentials,
                      _localizer.GetString(MessageCodes.InvalidCredentials)?.Value ?? "", System.Net.HttpStatusCode.BadRequest);

        var result = await _userManager.CheckPasswordAsync(user, model.Password);

        if (!result)
            throw new DailException(MessageCodes.InvalidCredentials,
                      _localizer.GetString(MessageCodes.InvalidCredentials)?.Value ?? "", System.Net.HttpStatusCode.BadRequest);

        var roles = await _userManager.GetRolesAsync(user);

        var token = _jwtHandler.GenerateToken(user, roles.ToList());
        return token;
    }

    public async Task<string> UpdateUserAsync(UserDTO model)
    {
        var user = await _userManager.Users.SingleOrDefaultAsync(u => u.UserName == model.UserName);

        if (user == null)
            throw new DailException(MessageCodes.NotFound,
                _localizer.GetString(MessageCodes.NotFound)?.Value ?? "", System.Net.HttpStatusCode.NotFound);

        _mapper.Map(model, user);

        var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
            throw new ValidationException(result.Errors);

        return user.Id;
    }
}