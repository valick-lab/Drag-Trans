namespace DragTrans.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public String UserName { get; set; } = String.Empty;
    public String PasswordHash { get; set; } = String.Empty;
    public DateTime CreateTime { get; set; }
}
