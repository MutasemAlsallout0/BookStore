using BookStore.API.Models;

namespace BookStore.API.Interfaces.Repositories
{
    public interface IZoneRepository
    {
        Task<List<Zone>> GetAllZonesAsync();
        Task<Zone> GetZoneByIdAsync(int id);
        Task<Zone> CreateAsync(Zone zoneToCreate);
        Task<Zone> UpdateAsync(int id, Zone zoneToUpdate);
        Task<bool> DeleteAsync(int id);
    }
}
