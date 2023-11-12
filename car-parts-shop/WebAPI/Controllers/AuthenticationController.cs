using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Authentication.Queries.Login;
using Application.Features.Authentication.Commands.Register;
using WebAPI.Entities.Authentication;

namespace WebAPI.Controllers;

[Route("/api")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly ISender _sender;

    public AuthenticationController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);
        var response = await _sender.Send(query);
        return Ok(response);
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(
            request.Firstname,
            request.Lastname,
            request.PhoneNumber,
            request.Email,
            request.Password);

        var response = await _sender.Send(command);
        return Ok(response);
    }
}
