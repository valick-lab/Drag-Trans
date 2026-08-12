using DragTrans.Application.Interfaces;
using DragTrans.Domain.Entities;
using System.Data;

namespace DragTrans.Application.Services.Register;

public class RegisterService
{
    private readonly IUserRepository _userRepository;

    public RegisterService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
    {
        var exitingUser = await _userRepository.GetByUserNameAsync(request.UserName);
        if (exitingUser != null)
        {
            throw new Exception("Это имя пользователя уже используется");
        }
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var user = new User
        {
            Id = Guid.NewGuid(),
            UserName = request.UserName,
            PasswordHash = passwordHash,
            CreateTime = DateTime.UtcNow
        };
        
        await _userRepository.AddAsync(user);

        return new RegisterResponse
        {
            Id = user.Id,
            UserName = user.UserName
        };
    }
}
