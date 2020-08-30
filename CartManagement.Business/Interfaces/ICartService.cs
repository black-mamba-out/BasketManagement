using System;
using System.Collections.Generic;
using CartManagement.Domain.Entities;

namespace CartManagement.Business.Interfaces
{
    public interface ICartService
    {
        Product GetProduct(int id);
        List<Product> GetProducts();
    }
}
