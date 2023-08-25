using BookStore.API.Models;

namespace BookStore.API.Interfaces.Repositories
{
    public interface IBookSuggestionsRepository
    {
        public Task<BookSuggestion> AddAsync(BookSuggestion bookSuggestion);
        public Task<List<BookSuggestion>> GetAllAsync();
        public Task<BookSuggestion> GetById(int bookSuggestionId);

        public Task<bool> DeleteAsync(int bookSuggestionId);
        public Task<bool> MarkAsRead(int bookSuggestionId);
        public Task<bool> MarkAsUnread(int bookSuggestionId);
    }
}
