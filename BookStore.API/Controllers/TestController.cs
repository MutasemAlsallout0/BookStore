using BookStore.API.Data;
using BookStore.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly BookStoreDbContext _context;

        public TestController(BookStoreDbContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<IActionResult> Test()
        {


            var sales = await _context.Sales.ToListAsync();


            //  var list = sales.GroupBy(s => s.BookId).Select(g=> new {bookId = g.Key, totalAmount  = g.Sum(s=>s.Amount)});
             var list = sales.GroupBy(s => s.BookId).Select(g=> new {bookId = g.Key, totalPrice = g.Sum(s => s.TotalPrice) });
            //   ---> example : {bookid =5 , totalAmount =100}

            //var maxOrderdBookId = sales.GroupBy(s => s.BookId).Select(g => new { bookId = g.Key, totalAmount = g.Sum(s => s.Amount) })
            //    .MaxBy(s => s.totalAmount);


            var mostSoldBookId = sales.GroupBy(s => s.BookId).Select(g => new { bookId = g.Key, totalPrice = g.Sum(s => s.TotalPrice) })
             .MaxBy(s => s.totalPrice);

           // var mostSoldBookId =  _context.Sales.GroupBy(s => s.BookId)
             //   .Select(g => new { bookId = g.Key, totalPrice = g.Sum(s => s.TotalPrice) }).MaxBy(s => s.totalPrice);






            return Ok(new { mostSoldBookId = mostSoldBookId}) ;
        }

    }

}
