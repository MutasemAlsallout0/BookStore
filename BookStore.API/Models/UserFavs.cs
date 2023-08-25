using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.API.Models
{
    public class UserFavs
    {
        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }


        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book { get; set; }

    }
}
