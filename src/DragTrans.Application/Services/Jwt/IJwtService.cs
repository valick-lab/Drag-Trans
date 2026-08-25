namespace DragTrans.Application.Services.Jwt;

public interface IJwtService
{
    string GenerateToken(Guid userId, string userName);
}