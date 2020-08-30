using System;
namespace CartManagement.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool RecordStatus { get; set; }
    }
}
