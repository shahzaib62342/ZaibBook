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
            var _writer = _context.Writer.FirstOrDefault(x => x.Id == writer.Id);
            if (_writer != null)
            {
                _writer.Name= writer.Name
            }
        }
    }
}
