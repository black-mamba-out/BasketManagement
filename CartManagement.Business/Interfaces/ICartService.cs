using System;
using System.Collections.Generic;
using CartManagement.Domain.Entities;
using CartManagement.Domain.Responses;

namespace CartManagement.Business.Interfaces
{
    public interface ICartService
    {
        AddProductToCartResponse AddProductToCart(int customerId, int productId, int quantity);
    }
}
