using VeterinarSite.Shared.Models;

namespace VeterinarSite.Shared.Services;

public interface IFileStream
{
    Task<Stream?> GetFileStream(GetFileModel model);
    Task<string?> GetBase64String(GetFileModel model);
}