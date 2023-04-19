namespace VeterinarSite.Persistance.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public byte[] Password { get; set; }
    public byte[] PasswordSalt { get; set; }
    public string? Role { get; set; }
    public string Email { get; set; }
    public string? Phone { get; set; }
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime? TokenCreated { get; set; }
    public DateTime? TokenExpires { get; set; }
}