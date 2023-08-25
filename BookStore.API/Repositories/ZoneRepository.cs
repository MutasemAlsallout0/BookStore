using BookStore.API.Data;
using BookStore.API.Interfaces.Repositories;
using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class ZoneRepository : IZoneRepository
    {
        private readonly BookStoreDbContext _context;

        public ZoneRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Zone>> GetAllZonesAsync()
        {
            return await _context.Zones.ToListAsync();
        }

        public async Task<Zone> GetZoneByIdAsync(int id)
        {
            return await _context.Zones.FindAsync(id);
        }


        public async Task<Zone> CreateAsync(Zone zoneToCreate)
        {
            await _context.Zones.AddAsync(zoneToCreate);
            await _context.SaveChangesAsync();
            return zoneToCreate;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var zone = await _context.Zones.FindAsync(id);
            if (zone == null) return false;

            _context.Zones.Remove(zone);
            return await _context.SaveChangesAsync() > 0;
        }



        public async Task<Zone> UpdateAsync(int id, Zone zoneToUpdate)
        {
            var zone = await _context.Zones.FirstOrDefaultAsync(a => a.Id == id);
            if (zone == null) return null;

            zone.Name = zoneToUpdate.Name;
            await _context.SaveChangesAsync();

            return zone;
        }
    }
}
