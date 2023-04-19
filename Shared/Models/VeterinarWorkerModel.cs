using System.ComponentModel.DataAnnotations;

namespace VeterinarSite.Shared.Models;

public class VeterinarWorkerModel
{
    public Guid? Id { get; set; }
    [Required] public string FirstName { get; set; }
    [Required] public string lastName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    [Required] public string CodCMV { get; set; }
    [Required] public string DiplomNumber { get; set; }
    [Required] public DateTime DateEnterCMv { get; set; }
    public bool IsActive { get; set; }
    public string? Sanctions { get; set; }
}