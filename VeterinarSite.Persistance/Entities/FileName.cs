namespace VeterinarSite.Persistance.Entities;

public class FileName
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? FileType { get; set; }
    public Guid? FileContentId { get; set; }
    public FileContent FileContent { get; set; }
}