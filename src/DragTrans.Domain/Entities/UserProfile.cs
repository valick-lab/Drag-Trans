namespace DragTrans.Domain.Entities;

public class UserProfile
{
    public Guid UserId { get; set; }

    public string Description { get; set; } = string.Empty;

    public string AvatarFilePath { get; set; } = string.Empty;

    public ICollection<StoredFile> Files { get; set; } = new List<StoredFile>();

    public User User { get; set; } = null!;
}