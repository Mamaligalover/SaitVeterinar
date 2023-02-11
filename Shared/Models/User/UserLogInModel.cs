using System.ComponentModel.DataAnnotations;

namespace VeterinarSite.Shared.Models.User;

public class UserLogInModel
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}