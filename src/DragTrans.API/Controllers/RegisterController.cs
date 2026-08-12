using DragTrans.Application.Services.Register;
using Microsoft.AspNetCore.Mvc;

namespace DragTrans.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly RegisterService _registerService;

    public AuthController(RegisterService registerService)
    {
        _registerService = registerService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<RegisterResponse>> Register(
        RegisterRequest request)
    {
        var response = await _registerService.RegisterAsync(request);

        return Ok(response);
    }
}