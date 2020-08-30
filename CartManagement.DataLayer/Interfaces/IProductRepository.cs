using System;
using System.Collections.Generic;
using CartManagement.Domain.Entities;

namespace CartManagement.DataLayer.Interfaces
{
    public interface IProductRepository
    {
        Product GetProduct(int id);
        List<Product> GetProducts();
    }
}
