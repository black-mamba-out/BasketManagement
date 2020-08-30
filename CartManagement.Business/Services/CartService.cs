using System;
using CartManagement.Business.Interfaces;
using CartManagement.DataLayer.Interfaces;
using CartManagement.Domain;
using CartManagement.Domain.Entities;
using CartManagement.Domain.Responses;

namespace CartManagement.Business.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;

        public CartService(ICartRepository cartRepository, ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        public AddProductToCartResponse AddProductToCart(int productId, int customerId, int quantity)
        {
            Product product = _productRepository.GetProduct(productId);
            if (product == null)
            {
                return new AddProductToCartResponse {
                    ErrorMessage = ConstantMessages.PRODUCT_NOT_FOUND
                };
            }
            if (product.Quantity <= 0)
            {
                return new AddProductToCartResponse {
                    ErrorMessage = ConstantMessages.NO_STOCK,
                    ProductName = product.Name
                };
            }
            if (product.Quantity < quantity)
            {
                return new AddProductToCartResponse {
                    ErrorMessage = ConstantMessages.NOT_ENOUGH_STOCK,
                    ProductName = product.Name
                };
            }
            Customer customer = _customerRepository.GetCustomer(customerId);
            if (customer == null)
            {
                return new AddProductToCartResponse {
                    ErrorMessage = ConstantMessages.CUSTOMER_NOT_FOUND,
                    ProductName = product.Name
                };
            }
            _cartRepository.AddProductToCart(product, customer, quantity);
            return new AddProductToCartResponse {
                ResultMessage = ConstantMessages.PRODUCT_ADDED,
                ProductName = product.Name
            };
        }

    }
}
