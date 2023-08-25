using BookStore.API.Data;
using BookStore.API.Models;

namespace BookStore.API.Interfaces.Repositories
{
    public interface IOrderNotificationRepository
    {


        Task<OrderNotification> AddNotificationAsync(OrderNotification notificationToAdd);
        Task<List<OrderNotification>> GetAllNotificationsAsync();
      
    }
}
