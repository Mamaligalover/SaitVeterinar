using Microsoft.AspNetCore.SignalR;
using HubNotification = Microsoft.AspNetCore.SignalR.Hub;
namespace VeterinarSite.Server.Hub;

public class UpdateDataHub : HubNotification
{
    public async Task NotifyMedicalWorkersHasChanged()
    {
        await Clients.All.SendAsync("NotifyMedicalWorkersHasChanged");
    }
        
    
}