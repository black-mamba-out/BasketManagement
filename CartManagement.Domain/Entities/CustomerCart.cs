using System;
using System.Collections.Generic;

namespace CartManagement.Domain.Entities
{
    public class CustomerCart
    {
        public Customer Customer { get; set; }
        public List<CartProduct> CartProducts { get; set; }
    }
}
