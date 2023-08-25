using BookStore.API.Data;
using BookStore.API.Interfaces.Repositories;
using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookStoreDbContext _context;

        public AuthorRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            return await _context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == id);
        }


        public async Task<Author> CreateAsync(Author authorToCreate)
        {
            await _context.Authors.AddAsync(authorToCreate);
            await _context.SaveChangesAsync();
            return authorToCreate;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null) return false;

            _context.Authors.Remove(author);
            return await _context.SaveChangesAsync() > 0;
        }

       

        public async Task<Author> UpdateAsync(int id, Author authorToUpdate)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);
            if (author == null) return null;

            author.Name = authorToUpdate.Name;
            await _context.SaveChangesAsync();

            return author;
        }

      

        public async Task<List<Book>> GetAuthorBooksAsync(int authorId)
        {
            return await _context.Books.Where(b => b.AuthorId == authorId).ToListAsync();
        }

     
    }
}
