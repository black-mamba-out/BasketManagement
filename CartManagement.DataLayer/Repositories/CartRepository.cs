using System;
using System.Collections.Generic;
using System.Linq;
using CartManagement.DataLayer.Interfaces;
using CartManagement.Domain.Entities;

namespace CartManagement.DataLayer.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly CartManagementDbContext _context;

        public CartRepository(CartManagementDbContext context)
        {
            _context = context;
        }
        public void AddProduct(Guid cartId, Customer customer, Product product)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int id)
        {
            return _context.Products.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
