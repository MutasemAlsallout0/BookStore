using BookStore.API.DTOs.BookDto.Repsonse;

namespace BookStore.API.DTOs.CategoryDto
{
    public class CategoryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    public class CategoryDetailsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<BookResponse> Books { get; set; }
    }
}
