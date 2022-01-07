using Microsoft.AspNetCore.Mvc;
using MiniCommerce.Customer.Domain.Services;

namespace MiniCommerce.Customer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController: ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Customer.Domain.Entities.Customer>))]
        public async Task<IActionResult> Get()
        {
            return Ok(await customerService.GetAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Customer.Domain.Entities.Customer))]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await customerService.GetById(id));
        }

        [HttpPost]
        public async Task Post(Customer.Domain.Entities.Customer customer)
        {
            await customerService.Post(customer);
        }

        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await customerService.Delete(id);
        }

        [HttpPut]
        public async Task Update(Customer.Domain.Entities.Customer customer)
        {
            await customerService.Update(customer);
        }

    }
}
