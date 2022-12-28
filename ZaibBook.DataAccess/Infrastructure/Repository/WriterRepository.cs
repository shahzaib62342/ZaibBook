using ZaibBook.DataAccess.Infrastructure.IRepository;
using ZaibBook.Models;

namespace ZaibBook.DataAccess.Infrastructure.Repository
{
    public class WriterRepository : Repository<Writer>, IWriterRepository
    {
        private readonly ApplicationDbContext _context;
        public WriterRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Update(Writer writer)
        {
            _context.Update(writer);
        }
    }
}
