using BookStore.API.Data;
using BookStore.API.Helpers;
using BookStore.API.Interfaces.Repositories;
using BookStore.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDbContext _context;

        public BookRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllBooksAsync(BookParams bookParams)
        {
            var books = _context.Books.OrderByDescending(b => b.Id).AsQueryable();
           
          

            if(bookParams.BookName != null)
            {
                books = books.Where(b => b.Name.Contains(bookParams.BookName));
            }

            if (bookParams.AuthorName != null)
            {
                books = books.Where(b => b.Author.Name.Contains(bookParams.AuthorName));
            }
            if (bookParams.publisherName != null)
            {
                books = books.Where(b => b.Publisher.Name.Contains(bookParams.publisherName));
            }
            if (bookParams.Year != 0)
            {
                books = books.Where(b => b.PublishYear == bookParams.Year);
            }

            if (bookParams.TakeCount != 0)
            {
                books = books.Take(bookParams.TakeCount);
            }

            return await books.ToListAsync();

        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(b=>b.Id==id);
        }
        public async Task<Book> CreateAsync(Book bookToCreate)
        {
            await _context.Books.AddAsync(bookToCreate);
            await _context.SaveChangesAsync();

            
            return await GetBookByIdAsync(bookToCreate.Id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return false;

            _context.Books.Remove(book);
            return await _context.SaveChangesAsync() > 0;
        }

      

        public async Task<Book> UpdateAsync(int id, Book bookToUpdate)
        {
            var book = await _context.Books.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
            if (book == null) return null;

            // if no image was uploaded then dont chage the image and keep it the same
            if(bookToUpdate.Image == null)
            {
                bookToUpdate.Image = book.Image;
            }

            bookToUpdate.Id = book.Id;
          


            _context.Books.Update(bookToUpdate);
            await _context.SaveChangesAsync();
            return await GetBookByIdAsync(bookToUpdate.Id);


        }

        public async Task<Book> GetLatestBookAsync()
        {
            return await _context.Books.IgnoreAutoIncludes().OrderByDescending(b => b.Id).FirstOrDefaultAsync();
        }

    

        public async Task<bool> AddToFavorite(string userId, int bookId)
        {
            //validate ids
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;

            var book = await _context.Books.FindAsync(bookId);
            if (book == null) return false;

            //validate if he already added it to fav
            var userFav = new UserFavs { AppUserId = userId, BookId = bookId };
            var result = await _context.UserFavs.AsNoTracking().SingleOrDefaultAsync(u => u.AppUserId == userFav.AppUserId && u.BookId == userFav.BookId);

            if (result != null) return false;

            await _context.UserFavs.AddAsync(userFav);
            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<bool> RemoveFromFavorite(string userId, int bookId)
        {
            //validate ids
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return false;

            var book = await _context.Books.FindAsync(bookId);
            if (book == null) return false;

            //validate if its exist on database 
            var userFav = new UserFavs { AppUserId = userId, BookId = bookId };

            var result = await _context.UserFavs.AsNoTracking().SingleOrDefaultAsync(u => u.AppUserId == userFav.AppUserId && u.BookId == userFav.BookId);

            if (result == null) return false;

             _context.UserFavs.Remove(userFav);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Book>> GetUserFavoriteBooks(string userId)
        {
            //validate ids
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return null;

            return  await _context.UserFavs.Where(uf => uf.AppUserId == userId).Select(uf => uf.Book).ToListAsync();

    

        }

        public async Task<BookReviews> AddReview(BookReviews bookReview)
        {
            //validate ids
            var user = await _context.Users.FindAsync(bookReview.AppUserId);
            if (user == null) return null;

            var book = await _context.Books.FindAsync(bookReview.BookId);
            if (book == null) return null;

             _context.BookReviews.Add(bookReview);
          var isAdded =  await _context.SaveChangesAsync() > 0;

            if (!isAdded) return null;


            return bookReview;
        }


        public async Task<bool> RemoveReview(int reviewId)
        {
            var review = await _context.BookReviews.FirstOrDefaultAsync(br => br.Id == reviewId);
            if(review == null) { return false;}
           
            _context.BookReviews.Remove(review);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<BookReviews>> GetBookReviews(int bookId)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book == null) return null;

            return await _context.BookReviews.Include(br=>br.AppUser).Include(br =>br.Book).Where(br => br.BookId == bookId).ToListAsync();
            
        }

        public async Task<List<BookReviews>> GetUserReviews(string userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return null;

            return await _context.BookReviews.Include(br => br.AppUser).Include(br => br.Book).Where(br => br.AppUserId == userId).ToListAsync();



        }
    }
}
