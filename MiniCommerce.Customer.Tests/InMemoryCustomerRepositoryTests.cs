using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MiniCommerce.Customer.Infrastructure.Repositories;

namespace MiniCommerce.Customer.Tests
{
    public class InMemoryCustomerRepositoryTests
    {
        [Fact]
        public async Task GetAll_Should_ReturnCustomers_When_ListIsNotEmpty()
        {
            InMemoryCustomerRepository repository = new();
            await repository.Post(new Domain.Entities.Customer());
            await repository.Post(new Domain.Entities.Customer());
            await repository.Post(new Domain.Entities.Customer());

            var list = await repository.GetAll();
            
            Assert.NotNull(list);
            Assert.True(list.Count() == 3);
        }

        [Fact]
        public async Task GetAll_ShouldNot_ReturnCustomers_When_ListIsEmpty()
        {
            InMemoryCustomerRepository repository = new();

            var list = await repository.GetAll();

            Assert.Empty(list);
        }

        [Fact]
        public async Task Post_Should_CreateCustomer()
        {
            InMemoryCustomerRepository repository = new();
            Customer.Domain.Entities.Customer customer = new();
            customer.Id = Guid.NewGuid();
            
            await repository.Post(customer);
            var item = await repository.Get(x=> x.Id == customer.Id);

            Assert.Equal(customer, item);

        }

    }
}
