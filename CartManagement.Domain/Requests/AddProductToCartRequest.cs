using System;
namespace CartManagement.Domain.Requests
{
    public class AddProductToCartRequest : BaseRequest
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
