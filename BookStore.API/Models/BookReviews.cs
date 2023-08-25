using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.API.Models
{
    public class BookReviews
    {
        public int Id { get; set; }

        [ForeignKey("Owner")]

        public string AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book { get; set; }

        
        public int Rate { get; set; }

        public string Comment { get; set; }

    }
}
