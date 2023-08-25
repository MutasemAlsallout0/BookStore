using BookStore.API.Data;
using BookStore.API.Interfaces.Repositories;
using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class OrderNotificationRepository : IOrderNotificationRepository
    {
        private readonly BookStoreDbContext _context;

        public OrderNotificationRepository(BookStoreDbContext context)
        {
            _context = context;
        }
        public async Task<OrderNotification> AddNotificationAsync(OrderNotification notificationToAdd)
        {
           await _context.OrderNotifications.AddAsync(notificationToAdd);
            await _context.SaveChangesAsync();

            return notificationToAdd;
        }

        public async Task<List<OrderNotification>> GetAllNotificationsAsync()
        {
            return await _context.OrderNotifications.ToListAsync();
        }
    }
}
