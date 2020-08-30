using System;
namespace CartManagement.Domain.Entities
{
    public class Cart
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public bool RecordStatus { get; set; }
    }
}
