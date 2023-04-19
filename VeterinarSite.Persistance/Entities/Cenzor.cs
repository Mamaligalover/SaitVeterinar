namespace VeterinarSite.Persistance.Entities;

public class Cenzor :Peopple
{
    public string? Function { get; set; }
    public string? Description { get; set; }
    public Guid? FileNameId { get; set; }
    public FileName? FileNam { get; set; }
}