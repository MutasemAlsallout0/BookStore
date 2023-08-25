using BookStore.API.DTOs.BookDto.Repsonse;

namespace BookStore.API.DTOs.BookReviewsDto.Response
{
    public class PostPutBookReviewResponse
    {

        public int Id { get; set; }
        public string AppUserId { get; set; }

      

        public SpecficBookResponse Book { get; set; }

        
        public int Rate { get; set; }


        public string Comment { get; set; }
    }


    public class DisplaySpecficBookReviewResponse
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public string UserName { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }

        public int Rate { get; set; }


        public string Comment { get; set; }

    }
}
