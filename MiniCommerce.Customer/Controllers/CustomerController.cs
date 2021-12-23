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
        public async Task<IActionResult> Get()
        {
            return Ok(await customerService.GetAll());
        }
    }
}
