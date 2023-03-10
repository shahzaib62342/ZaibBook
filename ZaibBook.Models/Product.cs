using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaibBook.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use Alphabets only")]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public Guid WriterId { get; set; }
        [ValidateNever]
        public Category Category { get; set; }
        [ValidateNever]
        public Writer Writer { get; set; }
    }
}
