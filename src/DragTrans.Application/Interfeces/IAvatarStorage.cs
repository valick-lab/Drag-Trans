namespace DragTrans.Application.Interfeces;

public interface IAvatarStorage
{
    Task SaveAsync(Guid userId, Stream avatarStream);

    Task DeleteAsync(Guid userId);

    string GetAvatarPath(Guid userId);
}