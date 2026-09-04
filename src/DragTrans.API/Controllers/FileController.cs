using DragTrans.Application.Services.Files;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DragTrans.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FileController : ControllerBase
{
    private readonly FileService _fileservice;

    public FileController(FileService fileservice)
    {
        _fileservice = fileservice;
    }

    [Authorize]
    [HttpPost("upload")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file == null)
        {
            throw new ArgumentException("Файл пустой.");
        }

        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var storedFile = await _fileservice.UploadAsync(file, userId);

        return Ok(storedFile);
    }
}