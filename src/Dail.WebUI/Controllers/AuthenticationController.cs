using Dail.Application.Common.Interfaces;
using Dail.Application.Common.Models.DataTransferObjects;
using Dail.WebUI.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dail.WebUI.Controllers;

public class AuthenticationController : ApiController
{
    private readonly IIdentityService _identityService;

    public AuthenticationController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [AllowAnonymous]
    [HttpPost("[action]")]
    public async Task<string> Login(LoginDTO dtoModel)
    {
        return await _identityService.LoginUserAsync(dtoModel);
    }
}