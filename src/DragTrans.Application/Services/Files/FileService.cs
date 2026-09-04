using DragTrans.Application.Interfaces;
using DragTrans.Application.Interfeces;
using Microsoft.AspNetCore.Http;
using DragTrans.Domain.Entities;

namespace DragTrans.Application.Services.Files;

public class FileService
{
    private readonly IFileRepository _fileRepository;
    
    public FileService(IFileRepository fileRepository)
    {
        _fileRepository = fileRepository;
    }


    public async Task<StoredFile> UploadAsync(IFormFile file, Guid userId)
    {
        if (file == null || file.Length == 0)
            throw new ArgumentException("Файл пустой.");
    }
}
