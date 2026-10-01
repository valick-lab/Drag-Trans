using DragTrans.Application.Interfeces;
using Microsoft.Extensions.Configuration;

namespace DragTrans.Infrastructure.Storage;

public class AvatarStorage : IAvatarStorage
{
    private readonly string _profilesPath;

    public AvatarStorage(IConfiguration configuration)
    {
        var configuredPath = configuration["Storage:ProfilesPath"];

        if (string.IsNullOrWhiteSpace(configuredPath))
        {
            throw new InvalidOperationException("Storage:ProfilesPath не настроен.");
        }

        _profilesPath = Path.GetFullPath(configuredPath);

        Directory.CreateDirectory(_profilesPath);
    }

    public async Task SaveAsync(Guid userId, Stream avatarStream)
    {
        var userDirectory = Path.Combine(_profilesPath, userId.ToString());

        Directory.CreateDirectory(userDirectory);

        var avatarPath = Path.Combine(userDirectory, "Icon.png");

        if (File.Exists(avatarPath))
        {
            File.Delete(avatarPath);
        }

        await using var fileStream = new FileStream(avatarPath, FileMode.Create, FileAccess.Write, FileShare.None);

        await avatarStream.CopyToAsync(fileStream);
    }

    public Task DeleteAsync(Guid userId)
    {
        var avatarPath = Path.Combine(_profilesPath, userId.ToString(), "Icon.png");

        if (File.Exists(avatarPath))
        {
            File.Delete(avatarPath);
        }

        return Task.CompletedTask;
    }

    public string GetAvatarPath(Guid userId)
    {
        var avatarPath = Path.Combine(_profilesPath, userId.ToString(), "Icon.png");

        if (File.Exists(avatarPath))
        {
            return avatarPath;
        }    

        return Path.Combine( _profilesPath, "DefaultIcon.png");
    }
}