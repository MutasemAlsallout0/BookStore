using BookStore.API.DTOs.BookDto.Repsonse;
using Mapster;

namespace BookStore.API.DTOs.AuthorDto
{

    /*
     Basic data with no relations
     */
    public class AuthorResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

       
    } 
    
    /*
     
     This will have full detials inculding relaitions
     */
    public class AuthorDeatilsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookResponse> Books { get; set; }


    }
}
