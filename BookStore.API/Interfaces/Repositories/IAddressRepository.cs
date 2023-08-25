using BookStore.API.Models;

namespace BookStore.API.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        Task<List<Address>> GetAllAsync();
        Task<Address> GetByIdAsync(int id);
        Task<Address> CreateAsync(Address addressToCreate);
        Task<Address> UpdateAsync(int id, Address addressToUpdate);
        Task<bool> DeleteAsync(int id);
    }
}
