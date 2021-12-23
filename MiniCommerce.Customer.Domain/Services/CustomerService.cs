using MiniCommerce.Customer.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCommerce.Customer.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Entities.Customer> _repository;

        public CustomerService(IRepository<Entities.Customer> repository)
        {
            _repository = repository;
        }

        public async Task Delete(Entities.Customer entity)
        {
            await _repository.Delete(entity);
        }

        public async Task<IEnumerable<Entities.Customer>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Entities.Customer> GetById(Guid id)
        {
            return await _repository.Get(x => x.Id == id);
        }

        public async Task<Entities.Customer> GetByName(string name)
        {
            return await _repository.Get(x => x.Name == name);
        }

        public async Task<Entities.Customer> Post(Entities.Customer entity)
        {
            return await _repository.Post(entity);
        }

        public async Task<Entities.Customer> Update(Entities.Customer entity)
        {
            return await _repository.Update(entity);
        }
    }
}
