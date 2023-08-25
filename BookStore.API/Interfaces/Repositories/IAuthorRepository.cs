using BookStore.API.Models;

namespace BookStore.API.Interfaces.Repositories
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int id);
        Task<Author> CreateAsync(Author authorToCreate);
        Task<Author> UpdateAsync(int id, Author authorToUpdate);
        Task<bool> DeleteAsync(int id);

        Task<List<Book>> GetAuthorBooksAsync(int authorId);
    }
}
