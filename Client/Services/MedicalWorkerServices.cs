using System.Net.Http.Json;
using VeterinarSite.Shared.Models;
using VeterinarSite.Shared.Services;

namespace VeterinarSite.Client.Services;

public class MedicalWorkerServices : IMedicalWorker
{
    private readonly HttpClient _httpClient;

    public MedicalWorkerServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<IEnumerable<VeterinarWorkerModel>> GetAll()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<VeterinarWorkerModel>>("/api/MedicalWorker/get-all");
    }

    public async Task<IEnumerable<VeterinarWorkerModel>> AddorUpdate(VeterinarWorkerModel model)
    {
        var http = await _httpClient.PostAsJsonAsync("/api/MedicalWorker/add-or-update", model);
        var response = await http.Content.ReadFromJsonAsync<IEnumerable<VeterinarWorkerModel>>();
        return response;
    }

    public async Task<IEnumerable<VeterinarWorkerModel>> Delete(Guid id)
    {
        var http = await _httpClient.DeleteAsync($"/api/MedicalWorker/delete/{id}");
        var response = await http.Content.ReadFromJsonAsync<IEnumerable<VeterinarWorkerModel>>();
        return response;
    }

    public async Task<VeterinarWorkerModel> GetById(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<VeterinarWorkerModel>($"/api/MedicalWorker/get-by-id/{id}");
    }
}