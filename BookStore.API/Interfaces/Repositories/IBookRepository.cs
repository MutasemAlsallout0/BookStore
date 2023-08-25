using BookStore.API.Helpers;
using BookStore.API.Models;

namespace BookStore.API.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooksAsync(BookParams bookParams);
        Task<Book> GetBookByIdAsync(int id);
        Task<Book> CreateAsync(Book bookToCreate);
        Task<Book> UpdateAsync(int id, Book bookToUpdate);
        Task<bool> DeleteAsync(int id);

        Task<Book> GetLatestBookAsync();
    

        Task<bool> AddToFavorite(string userId, int bookId);
        Task<bool> RemoveFromFavorite(string userId, int bookId);

        Task<List<Book>> GetUserFavoriteBooks(string userId);

        Task<BookReviews> AddReview(BookReviews bookReview);
        Task<bool> RemoveReview(int reviewId);
        Task<List<BookReviews>> GetBookReviews(int bookId);
        Task<List<BookReviews>> GetUserReviews(string userId);
        


    }
}
