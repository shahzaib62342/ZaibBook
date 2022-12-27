using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaibBook.DataAccess.Infrastructure.Repository;
using ZaibBook.Models;

namespace ZaibBook.DataAccess.Infrastructure.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
    }
}
