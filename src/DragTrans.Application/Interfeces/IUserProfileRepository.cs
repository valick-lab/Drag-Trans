using DragTrans.Domain.Entities;

namespace DragTrans.Application.Interfaces;

public interface IUserProfileRepository
{
    Task<UserProfile?> GetProfileByUserNameAsync(string userName);
    Task<UserProfile?> GetProfileByUserIdAsync(Guid userId);
    Task UpdateDescriptionAsync(string description, Guid userId);
    Task UpdateAvatarFilePathAsync(string avatarFilePath, Guid userId);
    Task AddDefaultAsync(UserProfile profile);
    Task UpdateOnlineStatusAsync(Guid userId, bool isOnline);
}