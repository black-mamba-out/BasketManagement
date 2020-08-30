using CartManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CartManagement.DataLayer.Maps
{
    public class CartMap
    {
        public CartMap(EntityTypeBuilder<CartProduct> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.ToTable("cart_products");

            entityBuilder.Property(x => x.Id).HasColumnName("id");
            entityBuilder.Property(x => x.CustomerId).HasColumnName("customer_id");
            entityBuilder.Property(x => x.ProductId).HasColumnName("product_id");
            entityBuilder.Property(x => x.Quantity).HasColumnName("quantity");
            entityBuilder.Property(x => x.RecordStatus).HasColumnName("record_status");
        }
    }
}
