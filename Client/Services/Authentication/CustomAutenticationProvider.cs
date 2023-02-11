

using System.Security.Claims;
using System.Text.Json;
using Blazored.LocalStorage;
using VeterinarSite.Shared.Services;

namespace VeterinarSite.Client.Services.Authentication;

public class CustomAutenticationProvider : AuthenticationStateProvider
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;

    public CustomAutenticationProvider(HttpClient httpClient, ILocalStorageService localStorage)
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
    }
    
    
    
    
    public override async  Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var claims = new List<Claim>();
        var token = await _localStorage.GetItemAsync<string>("token");
        if (token != null)
        {
            var claimsPrincipal = ParseClaimsFromJwet(token);
            claims.AddRange(claimsPrincipal);
        }
        
        var identity = new ClaimsIdentity(claims, "jwt");
        var user = new ClaimsPrincipal(identity);
        var state = Task.FromResult(new AuthenticationState(user));
        NotifyAuthenticationStateChanged(state);
        return await state;
        
    }

   

    public static IEnumerable<Claim> ParseClaimsFromJwet(string jwt)
    {
        var payload = jwt.Split('.')[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
    }

    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }
        return Convert.FromBase64String(base64);
    }
}