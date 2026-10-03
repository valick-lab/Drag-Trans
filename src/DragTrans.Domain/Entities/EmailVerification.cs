namespace DragTrans.Domain.Entities;

public class EmailVerification
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string EmailCode { get; set; } = string.Empty;
    public DateTime ExpiresAt { get; set; }
}