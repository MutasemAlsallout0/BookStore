using BookStore.API.DTOs.BookDto.Repsonse;

namespace BookStore.API.DTOs.SalesDto.Response
{
    public class PostSalesResponse
    {
        public int Id { get; set; }
        public string AppUserId { get; set; } //tmp



        public SpecficBookResponse Book { get; set; }


        public int Amount { get; set; }

        public int TotalPrice { get; set; }



    }

    
}
