using System.Net.Http.Json;
using VeterinarSite.Shared.Models.BiroulExecutiv;
using VeterinarSite.Shared.Services;

namespace VeterinarSite.Client.Services.ScienceAndResearch;

public class ResearchService : IScieneceAndResearchService
{
    private readonly HttpClient _httpClient;

    public ResearchService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task Delete(Guid? Id)
    {
        await _httpClient.DeleteAsync($"/api/ScienceAndResearchService/delete/{Id}");
    }

    

    public async Task<IEnumerable<ComisionModel>> GetAll()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<ComisionModel>>("/api/ScienceAndResearchService/getall");
    }

    public async Task<ComisionModel> GetById(Guid? Id)
    {
        return await _httpClient.GetFromJsonAsync<ComisionModel>($"/api/ScienceAndResearchService/getbyid/{Id}");
    }

    public async Task AddorUpdate(ComisionModel model)
    {
        await _httpClient.PostAsJsonAsync("/api/ScienceAndResearchService/addorupdate", model);
    }

    public Task<bool> UploadImage()
    {
        throw new NotImplementedException();
    }
}