using Microsoft.AspNetCore.Http;
using VeterinarSite.Shared.Services;

namespace VeterinarSite.Client.Services.Authentication;

public class GetCurrentAuthenticatedUsername : ICurrentUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public GetCurrentAuthenticatedUsername(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    public string? GetCurrentUserId()
    {
        return _httpContextAccessor.HttpContext?.User?.FindFirst("Username").Value;
    }
}