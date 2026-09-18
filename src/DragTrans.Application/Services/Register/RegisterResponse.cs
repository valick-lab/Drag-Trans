namespace DragTrans.Application.Services.Register;

public class RegisterResponse
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public DateTime CreateTime { get; set; }
}
