using System.Net.Http.Json;
using VeterinarSite.Shared.Models.BiroulExecutiv;
using VeterinarSite.Shared.Services;

namespace VeterinarSite.Client.Services.Comision;

public class CenzorService : ICenzors
{
    private readonly HttpClient _httpClient;

    public CenzorService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task Delete(Guid? Id)
    {
        await _httpClient.DeleteAsync($"/api/Cenzors/delete/{Id}");
    }

    

    public async Task<IEnumerable<ComisionModel>> GetAll()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<ComisionModel>>("/api/Cenzors/getall");
    }

    public async Task<ComisionModel> GetById(Guid? Id)
    {
        return await _httpClient.GetFromJsonAsync<ComisionModel>($"/api/Cenzors/getbyid/{Id}");
    }

    public async Task AddorUpdate(ComisionModel model)
    {
        await _httpClient.PostAsJsonAsync("/api/Cenzors/addorupdate", model);
    }

    public Task<bool> UploadImage()
    {
        throw new NotImplementedException();
    }
}