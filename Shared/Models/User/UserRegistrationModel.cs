using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace VeterinarSite.Shared.Models.User;

public class UserRegistrationModel
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Role { get; set; }
}