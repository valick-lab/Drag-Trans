using DragTrans.Infrastructure.Data;
using DragTrans.Application.Interfaces;
using DragTrans.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DragTrans.Infrastructure.Repositories;

public class UserProfileRepository : IUserProfileRepository
{
    private readonly DragTransDbContext _dbContext;

    public UserProfileRepository (DragTransDbContext dbcontext)
    {
        _dbContext = dbcontext;
    }

    public async Task<UserProfile?> GetProfileByUserNameAsync(string userName)
    {
        return await _dbContext.UserProfiles.FirstOrDefaultAsync(profile => profile.User.UserName == userName);
    }

    public async Task<UserProfile?> GetProfileByUserIdAsync(Guid userId)
    {
        return await _dbContext.UserProfiles.FirstOrDefaultAsync(profile => profile.User.Id == userId);
    }

    public async Task AddAvatarAsync(Guid userId, string avatarFileName)
    {

    }

    public async Task UpdateAvatarAsync(Guid userId, string avatarFileName)
    {
    }
    public async Task CreateDefaultProfileAsync(Guid userId, string userName, string email)
    {
    }

    public async Task UpdateIsOnlineStatusAsync(Guid userId)
    {
    }

}