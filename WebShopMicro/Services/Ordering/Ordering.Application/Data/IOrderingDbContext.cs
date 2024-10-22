using Microsoft.EntityFrameworkCore;

namespace Ordering.Application.Data
{
    //use an abstraction to decouple Application layer from specific implementation of the DB in the infrastructure layer
    public interface IOrderingDbContext
    {
        DbSet<Customer> Customers { get; }
        DbSet<Order> Orders { get; }
        DbSet<OrderItem> OrderItems { get; }
        DbSet<Product> Products { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
