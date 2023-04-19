using System.Net.Http.Json;
using VeterinarSite.Shared.Models.BiroulExecutiv;
using VeterinarSite.Shared.Services.ComisiaDeDenotologiesilitigii;

namespace VeterinarSite.Client.Services.ComisionService;

public class ComisionService : IComisionService
{
    private readonly HttpClient _httpClient;

    public ComisionService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task Delete(Guid? Id)
    {
        await _httpClient.DeleteAsync($"/api/Comision/delete/{Id}");
    }

    

    public async Task<IEnumerable<ComisionModel>> GetAll()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<ComisionModel>>("/api/Comision/getall");
    }

    public async Task<ComisionModel> GetById(Guid? Id)
    {
        return await _httpClient.GetFromJsonAsync<ComisionModel>($"/api/Comision/getbyid/{Id}");
    }

    public async Task AddorUpdate(ComisionModel model)
    {
        await _httpClient.PostAsJsonAsync("/api/Comision/addorupdate", model);
    }

    public Task<bool> UploadImage()
    {
        throw new NotImplementedException();
    }
}