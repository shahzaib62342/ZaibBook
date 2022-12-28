using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ZaibBook.DataAccess.Infrastructure.IRepository
{
    //Generic Interface for common functions
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

       public T GetT(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entities);

    }
}
