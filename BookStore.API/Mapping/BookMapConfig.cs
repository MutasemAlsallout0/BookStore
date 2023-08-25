using BookStore.API.DTOs.AuthorDto;
using BookStore.API.DTOs.BookDto.Repsonse;
using BookStore.API.DTOs.BookReviewsDto.Response;
using BookStore.API.DTOs.PublisherDto;
using BookStore.API.Models;
using Mapster;

namespace BookStore.API.Mapping
{
    public class BookMapConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Book, BookResponse>();

            config.NewConfig<Publisher, PublisherResponse>();
            config.NewConfig<BookReviews, DisplaySpecficBookReviewResponse>()
                .Map(res => res.UserName, br => br.AppUser.UserName)
                .Map(res => res.BookName, br => br.Book.Name);



            //.IgnoreIf((b, br) => b.Author == null,br=>br.Author);
            //.Map(br => br.Publisher, b => b.Publisher, s => s.Publisher != null)
            //.Map(br => br.Translator, b => b.Translator, s => s.Translator != null)
            //.Map(br => br.Category, b => b.Category, s => s.Category != null);







        }
    }
}
