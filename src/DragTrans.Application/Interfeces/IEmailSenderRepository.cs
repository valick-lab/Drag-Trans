namespace DragTrans.Application.Interfeces;

public interface IEmailSenderRepository
{
    Task SendMessageAsync(string email, string subject, string message);
}
