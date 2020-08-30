using System;
using System.Collections.Generic;

namespace CartManagement.Domain.Entities
{
    public class CustomerCart
    {
        public Customer Customer { get; set; }
        public List<Cart> Products { get; set; }
    }
}
