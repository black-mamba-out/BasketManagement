using System;
namespace CartManagement.Domain.Entities
{
    public class CartProduct
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public bool RecordStatus { get; set; }
    }
}
