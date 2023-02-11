using System.Security.Principal;

namespace VeterinarSite.Data.Persistance.Entities;

public class BirouExecutivCMV : Peopple
{
    public string? Function { get; set; }
    public string? Description { get; set; }
    public Guid? FileNameId { get; set; }
    public FileName? FileNam { get; set; }
}