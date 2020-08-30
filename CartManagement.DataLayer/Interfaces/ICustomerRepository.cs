using System;
using System.Collections.Generic;
using CartManagement.Domain.Entities;

namespace CartManagement.DataLayer.Interfaces
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(int id);
        List<Customer> GetCustomers();
    }
}
