namespace VeterinarSite.Persistance.Entities;

public class LucratorMedical :Peopple
{
    public string? CodCMV { get; set; }
    public string? DiplomNumber { get; set; }
    public DateTime? DateEnterCMv { get; set; }
    public bool IsActive { get; set; }
    public string? Sanctions { get; set; }
    
}