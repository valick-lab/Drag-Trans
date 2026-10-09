using DragTrans.Domain.Entities;

namespace DragTrans.Application.Interfaces;

public interface IUserProfileRepository
{
    Task<UserProfile> GetProfileByUserNameAsync(string userName);
    Task<UserProfile> GetProfileByUserIdAsync(Guid userId);
    Task AddAvatarAsync(Guid userId, string avatarFileName);
    Task UpdateAvatarAsync(Guid userId, string avatarFileName);
    Task CreateDefaultProfileAsync(Guid userId, string userName, string email);
}