using Microsoft.Extensions.DependencyInjection;
using MiniCommerce.Customer.Domain.Repositories;
using MiniCommerce.Customer.Domain.Services;
using MiniCommerce.Customer.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCommerce.Customer.Infrastructure.Configurations
{
    public static class ServiceConfigurations
    {
        public static void AddServices(this IServiceCollection services) 
        {
            services.AddSingleton<IRepository<Domain.Entities.Customer>, InMemoryCustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
        }
    }
}
