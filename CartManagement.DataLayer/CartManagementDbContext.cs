using System;
using CartManagement.DataLayer.Maps;
using CartManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CartManagement.DataLayer
{
    public class CartManagementDbContext : DbContext
    {
        public CartManagementDbContext(DbContextOptions<CartManagementDbContext> options)
       : base(options)
        {

        }
        public DbSet<CartProduct> CartProducts { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new CartMap(modelBuilder.Entity<CartProduct>());
            new ProductMap(modelBuilder.Entity<Product>());
            new CustomerMap(modelBuilder.Entity<Customer>());
        }

    }
}
