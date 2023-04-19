using Microsoft.AspNetCore.SignalR;

namespace VeterinarSite.Server.Hub;

public class ComisionHub : Microsoft.AspNetCore.SignalR.Hub
{

    public async Task UpdateData()
    {
        await Clients.All.SendAsync("UpdateData");
    }
}