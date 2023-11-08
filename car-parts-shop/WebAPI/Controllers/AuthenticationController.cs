using Application.Entities;
using Application.Interfaces.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var response = await _authenticationService.Login(request);

        return Ok(response);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var response = await _authenticationService.Register(request);

        return Ok(response);
    }
}
