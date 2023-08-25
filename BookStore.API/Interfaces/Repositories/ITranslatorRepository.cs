using BookStore.API.Models;

namespace BookStore.API.Interfaces.Repositories
{
    public interface ITranslatorRepository
    {
        Task<List<Translator>> GetAllTranslatorsAsync();
        Task<Translator> GetTranslatorByIdAsync(int id);
        Task<Translator> CreateAsync(Translator translatorToCreate);
        Task<Translator> UpdateAsync(int id, Translator translatorToUpdate);
        Task<bool> DeleteAsync(int id);
    }
}
