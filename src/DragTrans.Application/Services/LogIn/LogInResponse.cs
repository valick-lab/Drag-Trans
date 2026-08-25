namespace DragTrans.Application.Services.LogIn;

public class LogInResponse
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
}
