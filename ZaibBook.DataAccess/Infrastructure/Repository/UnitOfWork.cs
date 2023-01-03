using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaibBook.DataAccess.Infrastructure.IRepository;

namespace ZaibBook.DataAccess.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ICategoryRepository Category { get; private set; }
        public IWriterRepository Writer { get; private set; }

        public IProductRepository Product { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Category = new CategoryRepository(context);
            Writer=new WriterRepository(context);
            Product = new ProductRepository(context);
        }
        

        public void Save()
        {
           _context.SaveChanges();
        }
    }
}
