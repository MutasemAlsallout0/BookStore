using BookStore.API.Data;
using BookStore.API.Interfaces.Repositories;
using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class BookSuggestionsRepository : IBookSuggestionsRepository
    {
        private readonly BookStoreDbContext _context;

        public BookSuggestionsRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<BookSuggestion> AddAsync(BookSuggestion bookSuggestion)
        {
            await _context.BookSuggestions.AddAsync(bookSuggestion);
            await _context.SaveChangesAsync();
            return bookSuggestion;
        }

        public async Task<bool> DeleteAsync(int bookSuggestionId)
        {
            var bookSuggestion = await _context.BookSuggestions.FindAsync(bookSuggestionId);
            if (bookSuggestion == null) return false;

            _context.BookSuggestions.Remove(bookSuggestion);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<BookSuggestion>> GetAllAsync()
        {
            return await _context.BookSuggestions.OrderByDescending(c => c.CreatedAt).ToListAsync();
        }

        public async Task<BookSuggestion> GetById(int bookSuggestionId)
        {
            return await _context.BookSuggestions.FirstOrDefaultAsync(c => c.Id == bookSuggestionId);
        }

        public async Task<bool> MarkAsRead(int bookSuggestionId)
        {
            var bookSuggestion = await _context.BookSuggestions.FindAsync(bookSuggestionId);
            if (bookSuggestion == null) return false;

            bookSuggestion.ReadAt = DateTime.Now;
            _context.BookSuggestions.Update(bookSuggestion);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> MarkAsUnread(int bookSuggestionId)
        {
            var bookSuggestion = await _context.BookSuggestions.FindAsync(bookSuggestionId);
            if (bookSuggestion == null) return false;

            bookSuggestion.ReadAt = null;
            _context.BookSuggestions.Update(bookSuggestion);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
