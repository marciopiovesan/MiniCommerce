using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCommerce.Customer.Domain.Services
{
    public interface ICustomerService
    {
        Task<Entities.Customer> GetById(Guid id);
        Task<Entities.Customer> GetByName(string name);
        Task<IEnumerable<Entities.Customer>> GetAll();
        Task<Entities.Customer> Post(Entities.Customer entity);
        Task Delete(Guid id);
        Task<Entities.Customer> Update(Entities.Customer entity);
    }
}
