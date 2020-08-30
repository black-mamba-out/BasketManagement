using System;
using System.Collections.Generic;
using CartManagement.Domain.Entities;

namespace CartManagement.DataLayer.Interfaces
{
    public interface ICartRepository
    {
        void AddProduct(Guid cartId, Customer customer, Product product);
        Product GetProduct(int id);
        List<Product> GetProducts();
        void Save();
    }
}
