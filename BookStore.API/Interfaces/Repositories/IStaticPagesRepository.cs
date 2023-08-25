using BookStore.API.Models;

namespace BookStore.API.Interfaces.Repositories
{
    public interface IStaticPagesRepository
    {
        Task<List<StaticPages>> GetAllAsync();
        Task<StaticPages> GetByIdAsync(int id);
        Task<StaticPages> GetByPageSlugAsync(string slug);
        Task<StaticPages> CreateAsync(StaticPages staticPageToCreate);
        Task<StaticPages> UpdateAsync(int id, StaticPages staticPageToUpdate);
        Task<bool> DeleteAsync(int id);
    }
}
