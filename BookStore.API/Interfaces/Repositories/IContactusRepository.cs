
using BookStore.API.Models;

namespace BookStore.API.Interfaces.Repositories
{
    public interface IContactusRepository
    {
        public Task<Contactus> AddAsync(Contactus contactus);
        public Task<List<Contactus>> GetAllAsync();
        public Task<Contactus> GetById(int contactusId);

        public Task<bool> DeleteAsync(int contactusId);
        public Task<bool> MarkAsRead(int contactusId);
        public Task<bool> MarkAsUnread(int contactusId);
    }
}
