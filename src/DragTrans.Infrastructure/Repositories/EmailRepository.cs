using DragTrans.Infrastructure.Data;
using DragTrans.Application.Interfaces;
using DragTrans.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace DragTrans.Infrastructure.Repositories;

public class EmailRepository : IEmailRepository
{
    private readonly DragTransDbContext _dbcontext;

    public EmailRepository(DragTransDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task<EmailVerification?> GetByUserIdAsync(Guid userid)
    {
        return await _dbcontext.EmailVerifications.FirstOrDefaultAsync(x => x.UserId == userid);
    }

    public async Task AddAsync(EmailVerification verification)
    {
        await _dbcontext.EmailVerifications.AddAsync(verification);
        await _dbcontext.SaveChangesAsync();
    }

    public async Task Delete(EmailVerification verification)
    {
        _dbcontext.EmailVerifications.Remove(verification);
        await _dbcontext.SaveChangesAsync();
    }
}
