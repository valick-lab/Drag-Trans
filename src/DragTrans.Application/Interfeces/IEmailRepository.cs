using DragTrans.Domain.Entities;

namespace DragTrans.Application.Interfaces;

public interface IEmailRepository
{
    Task<EmailVerification?> GetByUserIdAsync(Guid userid);
    Task AddAsync(EmailVerification verification);
    Task Delete(EmailVerification verification);

}