using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.API.Models
{
    public class AppUser :IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool IsActive { get; set; } = true;

        [ForeignKey("Address")]

        public int? AddressId { get; set; }
        public Address? Address { get; set; }
    }
}
