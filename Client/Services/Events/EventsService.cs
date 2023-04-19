using System.Net.Http.Json;
using VeterinarSite.Shared.Models.EventsModel;
using VeterinarSite.Shared.Services.Events;

namespace VeterinarSite.Client.Services.Events;

public class EventsService : IEventsService
{
    private readonly HttpClient _httpClient;
    private  const string baseUrl = "api/events";

    public EventsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<IEnumerable<AppointmentModel>> GetAllApointments()
    {
        var response = await _httpClient.GetFromJsonAsync<IEnumerable<AppointmentModel>>($"{baseUrl}/getall");
        return response;
    }

    public async Task Add(AppointmentModel model)
    {
        var httpresponse = await _httpClient.PostAsJsonAsync($"{baseUrl}/add",model);
        if (httpresponse.IsSuccessStatusCode)
        {
            return;
        }
    }

    public async Task Edit(AppointmentModel model)
    {
        var httpresponse = await _httpClient.PatchAsJsonAsync($"{baseUrl}/edit", model);
        if (httpresponse.IsSuccessStatusCode)
        {
            return;
        }
    }
}