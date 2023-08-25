using BookStore.API.Models;
using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTOs.SalesDto.Request
{
    public class AddSaleRequest
    {
       
       
        [Required]
        public int? Amount { get; set; }
        [Required]
        public int? TotalPrice { get; set; }
    }
}
