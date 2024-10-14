using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data
{
    public class DiscountContext : DbContext
    {
        public DbSet<Coupon> Coupons { get; set; } = default!;

        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon
                {
                    Id = 1,
                    ProductName = "Microsoft Surface Pro 9 5G SQ3 i7 8 GB 128 GB SSD Windows 11 14.4-Inch Laptop, Sapphire",
                    Description = "Surface Pro discount",
                    Amount = 150
                },
                new Coupon
                {
                    Id = 2,
                    ProductName = "ASUS Vivobook X515EA Intel® Core™ i7-1165G7 8GB 256GB SSD WIN 11Home",
                    Description = "Vivobook discount",
                    Amount = 100
                });
        }
    }
}
