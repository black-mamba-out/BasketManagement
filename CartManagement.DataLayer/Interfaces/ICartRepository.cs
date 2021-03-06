﻿using System;
using System.Collections.Generic;
using CartManagement.Domain.Entities;

namespace CartManagement.DataLayer.Interfaces
{
    public interface ICartRepository
    {
        void Save();
        void AddProductToCart(Product product, Customer customer, int quantity);
    }
}
