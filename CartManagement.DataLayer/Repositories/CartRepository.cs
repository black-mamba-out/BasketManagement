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

        public void AddProductToCart(Product product, Customer customer, int quantity)
        {
            CartProduct cartProduct = new CartProduct
            {
                ProductId = product.Id,
                CustomerId = customer.Id,
                Quantity = quantity
            };
            _context.CartProducts.Add(cartProduct);
        }



        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
