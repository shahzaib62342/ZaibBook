using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ZaibBook.Models.ViewModel
{
    public class ProductVM
    {
        public Product Product { get; set; }=new Product();
        [ValidateNever]
        public IEnumerable<Product> Products { get; set;} = new List<Product>();

        [ValidateNever]
        //IEnumirable List for Category Dropdown in Product
        public IEnumerable<SelectListItem> Categories { get; set; }

        [ValidateNever]
        //IEnumirable List for Writers Dropdown in Product
        public IEnumerable<SelectListItem> Writers { get; set; }
    }
}
