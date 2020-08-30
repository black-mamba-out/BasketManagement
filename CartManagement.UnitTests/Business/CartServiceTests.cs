using System;
using CartManagement.Business.Services;
using CartManagement.DataLayer.Interfaces;
using CartManagement.Domain;
using CartManagement.Domain.Entities;
using FluentAssertions;
using Moq;
using Xunit;

namespace CartManagement.UnitTests.Business
{
    public class CartServiceTests
    {
        private Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();
        private Mock<ICustomerRepository> mockCustomerRepository = new Mock<ICustomerRepository>();
        private Mock<ICartRepository> mockCartRepository = new Mock<ICartRepository>();

        private Product Product { get
            {
                return new Product
                {
                    Id = 1,
                    Name = "Test",
                    Description = "Test Desc",
                    Price = 100,
                    Quantity = 10,
                    RecordStatus = true
                };
            }
        }

        private Customer Customer
        {
            get
            {
                return new Customer
                {
                    Id = 1,
                    Name = "Test",
                    Email = "Test Email",
                    PhoneNumber = "Test PhoneNumber",
                    RecordStatus = true
                };
            }
        }

        [Fact]
        public void AddProductToCart_ProductIsNull_ReturnsProductNotFound()
        {
            // Arrange
            mockProductRepository.Setup(x => x.GetProduct(0))
                .Returns(default(Product));

            var sut = new CartService(mockCartRepository.Object, mockCustomerRepository.Object, mockProductRepository.Object);

            // Act
            var result = sut.AddProductToCart(0, 1, 1);

            // Assert
            result.ErrorMessage.Should().NotBeNullOrEmpty();
            result.ErrorMessage.Should().Be(ConstantMessages.PRODUCT_NOT_FOUND);
        }

        [Fact]
        public void AddProductToCart_QuantityIsEqualOrSmallerThanZero_ReturnsNoStock()
        {
            // Arrange
            var product = Product;
            product.Quantity = 0;

            mockProductRepository.Setup(x => x.GetProduct(It.IsAny<int>()))
                .Returns(product);

            var sut = new CartService(mockCartRepository.Object, mockCustomerRepository.Object, mockProductRepository.Object);

            // Act
            var result = sut.AddProductToCart(1, 1, 1);

            // Assert
            result.ErrorMessage.Should().NotBeNullOrEmpty();
            result.ErrorMessage.Should().Be(ConstantMessages.NO_STOCK);
        }

        [Fact]
        public void AddProductToCart_StockIsSmallerThanDemand_ReturnsNotEnoughStock()
        {
            // Arrange
            var product = Product;

            mockProductRepository.Setup(x => x.GetProduct(It.IsAny<int>()))
                .Returns(product);

            var sut = new CartService(mockCartRepository.Object, mockCustomerRepository.Object, mockProductRepository.Object);

            // Act
            var result = sut.AddProductToCart(1, 1, 15);

            // Assert
            result.ErrorMessage.Should().NotBeNullOrEmpty();
            result.ErrorMessage.Should().Be(ConstantMessages.NOT_ENOUGH_STOCK);
        }

        [Fact]
        public void AddProductToCart_CustomerIsNull_ReturnsCustomerNotFound()
        {
            // Arrange
            mockProductRepository.Setup(x => x.GetProduct(It.IsAny<int>()))
                .Returns(Product);

            mockCustomerRepository.Setup(x => x.GetCustomer(0))
                .Returns(default(Customer));

            var sut = new CartService(mockCartRepository.Object, mockCustomerRepository.Object, mockProductRepository.Object);

            // Act
            var result = sut.AddProductToCart(1, 0, 1);

            // Assert
            result.ErrorMessage.Should().NotBeNullOrEmpty();
            result.ErrorMessage.Should().Be(ConstantMessages.CUSTOMER_NOT_FOUND);
        }

        [Fact]
        public void AddProductToCart_EverythingIsOk_CallsAddProductToCartOnce()
        {
            // Arrange
            mockProductRepository.Setup(x => x.GetProduct(It.IsAny<int>()))
                .Returns(Product);

            mockCustomerRepository.Setup(x => x.GetCustomer(It.IsAny<int>()))
                .Returns(Customer);

            mockCartRepository.Setup(x => x.AddProductToCart(It.IsAny<Product>(), It.IsAny<Customer>(), It.IsAny<int>()))
                .Verifiable();

            var sut = new CartService(mockCartRepository.Object, mockCustomerRepository.Object, mockProductRepository.Object);

            // Act
            var result = sut.AddProductToCart(1, 1, 1);

            // Assert
            result.ResultMessage.Should().NotBeNullOrEmpty();
            result.ResultMessage.Should().Be(ConstantMessages.PRODUCT_ADDED);
        }
    }
}
