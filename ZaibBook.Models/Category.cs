using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ZaibBook.Models
{
    public class Category
    {
        [Key]
        public Guid ID { get; set; }
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use Alphabets only")]
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
