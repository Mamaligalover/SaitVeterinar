namespace VeterinarSite.Shared.Models.BiroulExecutiv;

public class ComisionModel
{
    public Guid? Id { get; set; }
    public string? FirstName { get; set; }
    public string? lastName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Function { get; set; }
    public string? Description { get; set; }
    public Guid? FileNameId { get; set; }
    public byte[]? FileContetnt { get; set; }
   
}