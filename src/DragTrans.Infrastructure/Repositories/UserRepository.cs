using DragTrans.Infrastructure.Data;
using DragTrans.Application.Interfaces;
using DragTrans.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DragTrans.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DragTransDbContext _dbContext;

    public UserRepository (DragTransDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User?> GetByUserNameAsync(string userName)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(user => user.UserName == userName);
    }

    public async Task AddAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }
    public async Task<User?> GetByIdAsync(Guid userId)
    {
        return await _dbContext.Users
            .FirstOrDefaultAsync(user => user.Id == userId);
    }
    public async Task UpdateAsync(User user)
    {
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
    }
}
