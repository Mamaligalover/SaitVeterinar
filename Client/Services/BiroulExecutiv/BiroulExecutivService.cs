using System.Net.Http.Json;
using VeterinarSite.Shared.Models.BiroulExecutiv;
using VeterinarSite.Shared.Services;

namespace VeterinarSite.Client.Services.BiroulExecutiv;

public class BiroulExecutivService :IBiroulExecutivService
{
    private readonly HttpClient _httpClient;

    public BiroulExecutivService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task Delete(Guid? Id)
    {
      await _httpClient.DeleteAsync($"/api/BiroulExecutive/delete/{Id}");
    }

    

    public async Task<IEnumerable<ComisionModel>> GetAll()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<ComisionModel>>("/api/BiroulExecutive/getall");
    }

    public async Task<ComisionModel> GetById(Guid? Id)
    {
        return await _httpClient.GetFromJsonAsync<ComisionModel>($"/api/BiroulExecutive/getbyid/{Id}");
    }

    public async Task AddorUpdate(ComisionModel model)
    {
        await _httpClient.PostAsJsonAsync("/api/BiroulExecutive/addorupdate", model);
    }

    public Task<bool> UploadImage()
    {
        throw new NotImplementedException();
    }
}