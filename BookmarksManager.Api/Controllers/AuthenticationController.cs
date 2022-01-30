using BookmarksManager.App.Contracts.Services;
using BookmarksManager.App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookmarksManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly ILogger<AuthenticationController> _logger;
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(ILogger<AuthenticationController> logger, IAuthenticationService authenticationService)
    {
        _logger = logger;
        _authenticationService = authenticationService;
    }

	[AllowAnonymous]
	[HttpPost]
	[Route("authenticate")]
	public async Task<IActionResult> Authenticate(UserAuthentication userAuthenticationDto)
	{
		var token = await _authenticationService.Authenticate(userAuthenticationDto);

		if (token == null)
		{
			return Unauthorized();
		}

		return Ok(token);
	}
}
