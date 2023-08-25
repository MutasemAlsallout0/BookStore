using BookStore.API.Models;
using Microsoft.AspNetCore.SignalR;

namespace BookStore.API.Hubs
{
    public class NotificationHub :Hub
    {
        public async Task SendNotification(OrderNotification orderNotification)
        {
            await Clients.Group("admin").SendAsync("ReceiveNotification", orderNotification);
        }
    }
}
