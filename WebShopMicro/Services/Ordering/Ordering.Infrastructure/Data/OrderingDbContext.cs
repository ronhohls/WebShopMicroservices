﻿using Microsoft.EntityFrameworkCore;
using Ordering.Application.Data;
using System.Reflection;

namespace Ordering.Infrastructure.Data
{
    public class OrderingDbContext : DbContext, IOrderingDbContext
    {
        public OrderingDbContext(DbContextOptions<OrderingDbContext> options)
            : base(options) { }

        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<Product> Products => Set<Product>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
