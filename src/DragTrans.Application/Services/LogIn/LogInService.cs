using DragTrans.Application.Interfaces;

namespace DragTrans.Application.Services.LogIn;

public class LogInService
{
    private readonly IUserRepository _userRepository;
    public LogInService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
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

        return new LogInResponse
        {
            Id = user.Id,
            UserName = user.UserName
        };
    }
}
