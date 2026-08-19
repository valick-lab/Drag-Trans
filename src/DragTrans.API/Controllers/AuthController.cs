using DragTrans.Application.Services.LogIn;
using DragTrans.Application.Services.Register;
using Microsoft.AspNetCore.Mvc;

namespace DragTrans.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly RegisterService _registerService;
    private readonly LogInService _loginService;

    public AuthController(RegisterService registerService, LogInService loginService)
    {
        _registerService = registerService;
        _loginService = loginService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<RegisterResponse>> Register(
        RegisterRequest request)
    {
        var response = await _registerService.RegisterAsync(request);

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<ActionResult<LogInResponse>> Login(
        LogInRequests request)
    {
        var response = await _loginService.LogInAsync(request);

        return Ok(response);
    }
}