using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataApp.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private CustomerEFDBContext _context;

        public CustomerRepository(CustomerEFDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers;
        }
    }
}
