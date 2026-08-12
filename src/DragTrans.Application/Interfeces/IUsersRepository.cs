using DragTrans.Domain.Entities;

namespace DragTrans.Application.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByUserNameAsync(string userName);

    Task AddAsync(User user);
}