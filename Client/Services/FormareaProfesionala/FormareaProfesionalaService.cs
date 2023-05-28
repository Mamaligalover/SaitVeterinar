using System.Net.Http.Json;
using VeterinarSite.Shared.Models;
using VeterinarSite.Shared.Services;

namespace VeterinarSite.Client.Services.FormareaProfesionala;

public class FormareaProfesionalaService :IFileStream
{
    private readonly HttpClient _httpClient;

    public FormareaProfesionalaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<Stream?> GetFileStream(GetFileModel model)
    {
        var response = await _httpClient.PostAsJsonAsync($"api/get-file/get-stream", model);
        return await response.Content.ReadAsStreamAsync() ;
    }
    public async Task<string?> GetBase64String(GetFileModel model)
    {
        var response = await _httpClient.PostAsJsonAsync($"api/get-file/get-bytearray", model);
        return await response.Content.ReadAsStringAsync() ;
    }
}