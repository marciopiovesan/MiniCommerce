using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCommerce.Customer.Domain.Repositories
{
    public interface IRepository<T>
    {
        Task<T?> Get(Func<T, bool> predicate);
        Task<IEnumerable<T>> GetAll();
        Task<T> Post(T entity);
        Task Delete(T entity);
        Task<T> Update(T entity);
    }
}
