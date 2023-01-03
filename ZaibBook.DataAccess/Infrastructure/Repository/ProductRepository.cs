using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaibBook.DataAccess.Infrastructure.IRepository;
using ZaibBook.Models;

namespace ZaibBook.DataAccess.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Product product)
        {
            var _product = _context.Products.FirstOrDefault(x => x.Id == product.Id);
            if (_product != null)
            {
                _product.Name = product.Name;
                _product.Description = product.Description;
                _product.Category = product.Category;
                _product.Price = product.Price;
                if (product.ImageUrl != null)
                {
                    _product.ImageUrl = product.ImageUrl;
                }
            }
        }
    }
}
