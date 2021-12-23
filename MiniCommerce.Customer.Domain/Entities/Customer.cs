using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCommerce.Customer.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        //public string Address { get; set; }
    }
}
