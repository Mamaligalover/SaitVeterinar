using VeterinarSite.Shared.Models.User;

namespace VeterinarSite.Shared.Services;

public interface IUserAuthentication
{
    Task<string> Register(UserRegistrationModel user);
    Task Login(UserLogInModel user);
}