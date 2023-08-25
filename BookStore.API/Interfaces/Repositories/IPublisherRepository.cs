using BookStore.API.Helpers;
using BookStore.API.Models;

namespace BookStore.API.Interfaces.Repositories
{
    public interface IPublisherRepository
    {
        Task<List<Publisher>> GetAllPublishersAsync(PublisherParams publisherParams);
        Task<Publisher> GetPublisherByIdAsync(int id);
        Task<Publisher> CreateAsync(Publisher publisherToCreate);
        Task<Publisher> UpdateAsync(int id, Publisher publisherToUpdate);
        Task<bool> DeleteAsync(int id);
    }
}
