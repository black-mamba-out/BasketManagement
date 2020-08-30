using System;
using System.Collections.Generic;
using CartManagement.Business.Interfaces;
using CartManagement.DataLayer.Interfaces;
using CartManagement.Domain.Entities;

namespace CartManagement.Business.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public Product GetProduct(int id)
        {
            return _cartRepository.GetProduct(id);
        }

        public List<Product> GetProducts()
        {
            return _cartRepository.GetProducts();
        }
    }
}
