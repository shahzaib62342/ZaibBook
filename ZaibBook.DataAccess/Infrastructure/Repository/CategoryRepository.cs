using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaibBook.DataAccess.Infrastructure.IRepository;
using ZaibBook.Models;

namespace ZaibBook.DataAccess.Infrastructure.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Category category)
        {
            var _category = _context.Categories.FirstOrDefault(x=>x.ID==category.ID);
            if (_category != null)
            {
                _category.Name = category.Name;
                _category.DisplayOrder = category.DisplayOrder;
            }
            
        }
    }
}
