using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniCommerce.Customer.Domain.Repositories;
using MiniCommerce.Customer.Domain.Services;
using Moq;
using Xunit;

namespace MiniCommerce.Customer.Tests
{
    public class CustomerServiceTests
    {
        [Fact]
        public async Task GetAll_Should_ReturnCustomers_When_ListIsNotEmpty()
        {
            Mock<IRepository<Customer.Domain.Entities.Customer>> mock = new();
            mock.Setup(x => x.GetAll()).ReturnsAsync(new[] { new Customer.Domain.Entities.Customer() });

            CustomerService service = new(mock.Object);

            var list = await service.GetAll();

            mock.Verify(x => x.GetAll());

            Assert.NotNull(list);
            Assert.NotEmpty(list);
        }

        [Fact]
        public async Task Post_Should_CreateCustomer()
        {
            Mock<IRepository<Customer.Domain.Entities.Customer>> mock = new();

            Customer.Domain.Entities.Customer customer = new();

            CustomerService service = new(mock.Object);

            await service.Post(customer);

            mock.Verify(x => x.Post(It.Is<Customer.Domain.Entities.Customer>(e => e == customer)));
        }

        [Fact]
        public async Task Update_Should_ThrowException_When_NameIsEmpty()
        {
            Mock<IRepository<Customer.Domain.Entities.Customer>> mock = new();

            Customer.Domain.Entities.Customer customer = new();

            CustomerService service = new(mock.Object);

            
            var task = (Domain.Entities.Customer a) => service.Update(a);
            Func<Domain.Entities.Customer, Task> func = service.Update;

            var coisa = service.Update;

            await coisa(customer);

            await func(customer);

            await task(customer);

            await Assert.ThrowsAsync<Exception>(() => service.Update(customer));

            //try
            //{
            //    await service.Update(customer);
            //}
            //catch (Exception e)
            //{
            //    Assert.NotNull(e);
            //}

            coisa1(() => coisa(customer));
        }

        private void coisa1(Func<Task> func)
        {
            func();
        }

    }
}
