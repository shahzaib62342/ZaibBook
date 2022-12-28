using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaibBook.Models;

namespace ZaibBook.DataAccess.Infrastructure.IRepository
{
    public interface IWriterRepository : IRepository<Writer>
    {
        void Update(Writer model);
    }
}
