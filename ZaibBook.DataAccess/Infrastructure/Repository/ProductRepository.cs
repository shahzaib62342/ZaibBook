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
            _context.Products.Update(product);
        }
    }
}
