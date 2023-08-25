using BookStore.API.Data;
using BookStore.API.Interfaces.Repositories;
using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class ContactusRepository : IContactusRepository
    {
        private readonly BookStoreDbContext _context;

        public ContactusRepository(BookStoreDbContext context)
        {
            _context = context;
        }
        public async Task<Contactus> AddAsync(Contactus contactus)
        {
          await  _context.Contactus.AddAsync(contactus);
            await _context.SaveChangesAsync();
            return contactus;
        }

        public async Task<bool> DeleteAsync(int contactusId)
        {
            var contactus = await _context.Contactus.FindAsync(contactusId);
            if (contactus == null) return false;

            _context.Contactus.Remove(contactus);
            return await _context.SaveChangesAsync() >0;
        }

        public async Task<List<Contactus>> GetAllAsync()
        {
            return await _context.Contactus.OrderByDescending(c => c.CreatedAt).ToListAsync();
        }

        public async Task<Contactus> GetById(int contactusId)
        {
            return await _context.Contactus.FirstOrDefaultAsync(c => c.Id == contactusId);
        }

        public async Task<bool> MarkAsRead(int contactusId)
        {
            var contactus = await _context.Contactus.FindAsync(contactusId);
            if (contactus == null) return false;

            contactus.ReadAt = DateTime.Now;
             _context.Contactus.Update(contactus);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> MarkAsUnread(int contactusId)
        {
            var contactus = await _context.Contactus.FindAsync(contactusId);
            if (contactus == null) return false;

            contactus.ReadAt = null;
            _context.Contactus.Update(contactus);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
