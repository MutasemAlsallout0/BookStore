using BookStore.API.Data;
using BookStore.API.Interfaces.Repositories;
using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly BookStoreDbContext _context;

        public AddressRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Address>> GetAllAsync()
        {
            return await _context.Addresses.Include(a=>a.Zone).ToListAsync();
        }

        public async Task<Address> GetByIdAsync(int id)
        {
            return await _context.Addresses.Include(a=>a.Zone).FirstOrDefaultAsync(b => b.Id == id);
        }


        public async Task<Address> CreateAsync(Address addressToCreate)
        {
            await _context.Addresses.AddAsync(addressToCreate);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(addressToCreate.Id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address == null) return false;

            _context.Addresses.Remove(address);
            return await _context.SaveChangesAsync() > 0;
        }



        public async Task<Address> UpdateAsync(int id, Address addressToUpdate)
        {
            var address = await _context.Addresses.Include(a=>a.Zone).FirstOrDefaultAsync(a => a.Id == id);
            if (address == null) return null;

            address.Address1 = addressToUpdate.Address1;
            address.Address2 = addressToUpdate.Address2;
            address.ZoneId = addressToUpdate.ZoneId;
            address.PostalCode = addressToUpdate.PostalCode;
            await _context.SaveChangesAsync();

            return await GetByIdAsync(id);
        }
    }
}
