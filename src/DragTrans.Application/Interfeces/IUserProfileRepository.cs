using DragTrans.Domain.Entities;

namespace DragTrans.Application.Interfaces;

public interface IUserProfileRepository
{
    Task<UserProfile?> GetProfileByUserNameAsync(string userName);
    Task<UserProfile?> GetProfileByUserIdAsync(Guid userId);
    Task AddAsync(UserProfile profile);
    Task UpdateAsync(UserProfile profile);
    Task SaveChangesAsync();
}