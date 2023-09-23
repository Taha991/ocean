using System;
using System.ComponentModel.DataAnnotations;

namespace oceantecsa.Models
{
    public class Sales
    {
        public int Id { get; set; }

       
        public int ProductId { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public decimal Discount { get; set; }

        [Required]
        public decimal TotalMoney { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public Product Product { get; set; } 
    }
}
