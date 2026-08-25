using DragTrans.Application.Interfaces;
using DragTrans.Application.Services.Jwt;

namespace DragTrans.Application.Services.LogIn;

public class LogInService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;
    public LogInService(IUserRepository userRepository, IJwtService jwtService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
    }

    public async Task<LogInResponse> LogInAsync(LogInRequests request)
    {
        var user = await _userRepository.GetByUserNameAsync(request.Username);
        if (user == null)
        {
            throw new Exception("Неверный пользователь, или пароль");
        }

        bool passwordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
        if (!passwordValid)
        {
            throw new Exception("Неверный пользователь, или пароль");
        }

        var token = _jwtService.GenerateToken(user.Id, user.UserName);

        return new LogInResponse
        {
            Id = user.Id,
            UserName = user.UserName,
            Token = token
        };
    }
}
