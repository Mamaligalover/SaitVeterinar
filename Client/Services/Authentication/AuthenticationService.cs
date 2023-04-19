using System.Net.Http.Json;
using Blazored.LocalStorage;
using Blazored.LocalStorage.StorageOptions;
using VeterinarSite.Shared.Models.User;
using VeterinarSite.Shared.Services;

namespace VeterinarSite.Client.Services.Authentication;

public class AuthenticationService :IUserAuthentication
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;

    public AuthenticationService(HttpClient httpClient, ILocalStorageService localStorage)
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
    }


    public async Task<string> Register(UserRegistrationModel user)
    {
        var messge = await _httpClient.PostAsJsonAsync("api/user/register", user);
        return await messge.Content.ReadAsStringAsync();
    }

    public async Task Login(UserLogInModel user)
    {
        var http = await _httpClient.PostAsJsonAsync("api/user/login", user);
        var token = await http.Content.ReadAsStringAsync();
        await _localStorage.SetItemAsync("token", token);
    }
}