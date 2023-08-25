using BookStore.API.Helpers;
using BookStore.API.Models;

namespace BookStore.API.Interfaces.Repositories
{
    public interface ISalesRepository
    {
        Task<Sales> AddBookSale(Sales bookSale);
        Task<Book> GetMostSoldBookAsync();
        Task<Book> GetMostOrderdBookAsync();

        Task<List<Sales>> GetUserSales(string userId);
        Task<List<Sales>> GetBookSales(int bookId, BookSalesParams bookSalesParams);
        Task<List<Sales>> GetAllSales();

        Task<Sales> UpdateStatus(int saleId,int status);

        Task<Sales> CheckIfUserOwnsBook(string userId,int bookId);



    }
}
