using System;
using System.Collections.Generic;
using System.Linq;
using CartManagement.DataLayer.Interfaces;
using CartManagement.Domain.Entities;

namespace CartManagement.DataLayer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CartManagementDbContext _context;

        public ProductRepository(CartManagementDbContext context)
        {
            _context = context;
        }

        public Product GetProduct(int id)
        {
            return _context.Products.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
    }
}
