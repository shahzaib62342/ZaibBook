using System.ComponentModel.DataAnnotations;

namespace ZaibBook.Models
{
    public class Writer
    {
        [Key]
        public Guid Id { get; set; }
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use Alphabets only")]
        [Required]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }= DateTime.Now;

    }
}
