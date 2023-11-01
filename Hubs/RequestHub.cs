using Microsoft.AspNetCore.SignalR;
using VenomVerseApi.DTO;

namespace VenomVerseApi.Hubs;

public class RequestHub : Hub
{
    public async Task ContactCatcher(ScannedImageDto image)
    {
        await Clients.All.SendAsync("ReceiveOrder", image);
    }
}