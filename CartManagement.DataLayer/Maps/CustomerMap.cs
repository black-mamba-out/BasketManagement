using System;
using CartManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CartManagement.DataLayer.Maps
{
    public class CustomerMap
    {
        public CustomerMap(EntityTypeBuilder<Customer> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.ToTable("customer");

            entityBuilder.Property(x => x.Id).HasColumnName("id");
            entityBuilder.Property(x => x.Name).HasColumnName("name");
            entityBuilder.Property(x => x.PhoneNumber).HasColumnName("phone_number");
            entityBuilder.Property(x => x.Email).HasColumnName("email");
            entityBuilder.Property(x => x.RecordStatus).HasColumnName("record_status");
        }
    }
}
