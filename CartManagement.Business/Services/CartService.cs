using System;
using CartManagement.Business.Interfaces;
using CartManagement.DataLayer.Interfaces;
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
            try
            {
                Product product = _productRepository.GetProduct(productId);
                if (product == null)
                {
                    return new AddProductToCartResponse {
                        ErrorMessage = "Ürün bulunamadı."
                    };
                }
                if (product.Quantity <= 0)
                {
                    return new AddProductToCartResponse {
                        ErrorMessage = "Bu ürün stokta bulunmamaktadır.", ProductName = product.Name
                    };
                }
                if (product.Quantity < quantity)
                {
                    return new AddProductToCartResponse {
                        ErrorMessage = string.Format("Bu üründen yeterince bulunmamaktadır. Stok adedi: {0}", product.Quantity ),
                        ProductName = product.Name
                    };
                }
                Customer customer = _customerRepository.GetCustomer(customerId);
                if (customer == null)
                {
                    return new AddProductToCartResponse {
                        ErrorMessage = "Müşteri bulunamadı.",
                        ProductName = product.Name
                    };
                }
                _cartRepository.AddProductToCart(product, customer, quantity);
                return new AddProductToCartResponse {
                    ResultMessage = string.Format("{0} ürünü sepetinize başarıyla eklendi.", product.Name),
                    ProductName = product.Name
                };
            }
            catch (Exception ex)
            {
                return new AddProductToCartResponse {
                    ErrorMessage= "Bir hata oluştu.Lütfen tekrar deneyiniz!"
                };
            }
            
        }

    }
}
