using System;
using System.Collections.Generic;
using System.Linq;
using CartManagement.DataLayer.Interfaces;
using CartManagement.Domain.Entities;

namespace CartManagement.DataLayer.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CartManagementDbContext _context;

        public CustomerRepository(CartManagementDbContext context)
        {
            _context = context;
        }

        public Customer GetCustomer(int id)
        {
            return _context.Customers.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }
    }
}
