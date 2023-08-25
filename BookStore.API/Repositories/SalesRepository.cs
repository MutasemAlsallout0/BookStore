using BookStore.API.Data;
using BookStore.API.Helpers;
using BookStore.API.Interfaces.Repositories;
using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class SalesRepository : ISalesRepository
    {
        private readonly BookStoreDbContext _context;

        public SalesRepository(BookStoreDbContext context)
        {
            _context = context;
        }
        public async Task<Sales> AddBookSale(Sales bookSale)
        {
            //validate ids
            var user = await _context.Users.FindAsync(bookSale.AppUserId);
            if (user == null) return null;

            var book = await _context.Books.FindAsync(bookSale.BookId);
            if (book == null) return null;


            _context.Sales.Add(bookSale);
            var isAdded = await _context.SaveChangesAsync() > 0;

            if (!isAdded) return null;


            return bookSale;
        }

        public async Task<Book> GetMostOrderdBookAsync()
        {
            //  var sales = await _context.Sales.ToListAsync();

       
             var maxOrderdBookId = _context.Sales.AsEnumerable().GroupBy(s => s.BookId)
                .Select(g => new { bookId = g.Key, totalAmount = g.Sum(s => s.Amount) })
                .MaxBy(s => s.totalAmount);

            if (maxOrderdBookId == null) return null;

            return await _context.Books.FirstOrDefaultAsync(b=>b.Id == maxOrderdBookId.bookId);


        }

        public async Task<Book> GetMostSoldBookAsync()
        {

          //  var sales = await _context.Sales.ToListAsync();
            var mostSoldBookId = _context.Sales.AsEnumerable().GroupBy(s => s.BookId)
                .Select(g => new { bookId = g.Key, totalPrice = g.Sum(s => s.TotalPrice) })
               .MaxBy(s => s.totalPrice);

            if (mostSoldBookId == null) return null;


            return await _context.Books.FirstOrDefaultAsync(b => b.Id == mostSoldBookId.bookId);


        }


        public async Task<List<Sales>> GetUserSales(string userId)
        {
            //validate ids
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return null;

            return await _context.Sales.Include(s=>s.Book).Where(s => s.AppUserId == userId).OrderByDescending(s => s.Id).ToListAsync();
        }

        public async Task<List<Sales>> GetBookSales(int bookId, BookSalesParams bookSalesParams)
        {
         
            var sale = _context.Sales.Where(s => s.BookId == bookId).AsQueryable();
            if(bookSalesParams.FromDate != null) {
                sale = sale.Where(s => s.OrderDate >= bookSalesParams.FromDate);
            }

            if(bookSalesParams.ToDate != null)
            {
                sale = sale.Where(s => s.OrderDate <= bookSalesParams.ToDate);

            }

            sale =  sale.Include(s => s.Book).Include(b => b.AppUser);

            return await sale.ToListAsync();
        }

        public async Task<List<Sales>> GetAllSales()
        {
            return await _context.Sales.Include(s=>s.Book).Include(s=>s.AppUser).OrderByDescending(s=>s.Id).ToListAsync();
        }

        public async Task<Sales> UpdateStatus(int saleId, int status)
        {
            var saleToUpdate = await _context.Sales.Include(s=>s.AppUser).Include(s=>s.Book).FirstOrDefaultAsync(s=>s.Id == saleId);
            if (saleToUpdate == null) return null;

            saleToUpdate.Status = status == 1 ? SalesStatus.SOLD : SalesStatus.CANCELED;
          
            
            await _context.SaveChangesAsync();

            return saleToUpdate;
        }

        public async Task<Sales> CheckIfUserOwnsBook(string userId,int bookId)
        {
            return await _context.Sales.Where(s => s.AppUserId == userId && s.BookId == bookId && s.Status == SalesStatus.SOLD).FirstOrDefaultAsync();
        }
    }
}
