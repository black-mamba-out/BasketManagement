using System;
using CartManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CartManagement.DataLayer.Maps
{
    public class CartMap
    {
        public CartMap(EntityTypeBuilder<Cart> entityBuilder)
        {
            entityBuilder.HasNoKey();
            entityBuilder.ToTable("cart");

            entityBuilder.Property(x => x.CustomerId).HasColumnName("customer_id");
            entityBuilder.Property(x => x.ProductId).HasColumnName("product_id");
            entityBuilder.Property(x => x.RecordStatus).HasColumnName("record_status");
        }
    }
}
