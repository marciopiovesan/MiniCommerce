using MiniCommerce.Customer.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCommerce.Customer.Infrastructure.Repositories
{
    public class InMemoryCustomerRepository : IRepository<Domain.Entities.Customer>
    {
        private IList<Domain.Entities.Customer> _entities;

        public InMemoryCustomerRepository()
        {
            _entities = new List<Domain.Entities.Customer>();
        }

        public async Task Delete(Guid id)
        {
            var customer = await Get(c => c.Id == id);
            await Task.FromResult(_entities.Remove(customer));
        }

        public async Task<Domain.Entities.Customer?> Get(Func<Domain.Entities.Customer, bool> predicate)
        {
            return await Task.FromResult(_entities.FirstOrDefault(predicate));
        }

        public async Task<IEnumerable<Domain.Entities.Customer>> GetAll()
        {
            return await Task.FromResult(_entities);
        }

        public async Task<Domain.Entities.Customer> Post(Domain.Entities.Customer entity)
        {
            _entities.Add(entity);
            return await Task.FromResult(entity);
        }

        public async Task<Domain.Entities.Customer> Update(Domain.Entities.Customer entity)
        {
            await Delete(entity.Id);
            return await Post(entity);
        }
    }
}
