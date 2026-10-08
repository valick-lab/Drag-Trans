using System;
using System.Net;
using System.Net.Mail;
using DragTrans.Application.Interfeces;

namespace DragTrans.Infrastructure.Repositories;

public class EmailSenderRepository : IEmailSenderRepository
{
    public async Task SendMessageAsync(string email, string subject, string message)
    {
        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential("your-email@gmail.com", "your-password")
    };
    }
}
