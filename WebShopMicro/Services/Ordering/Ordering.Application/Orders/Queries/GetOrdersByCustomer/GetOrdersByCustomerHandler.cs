using Microsoft.EntityFrameworkCore;

namespace Ordering.Application.Orders.Queries.GetOrdersByCustomer
{
    public class GetOrdersByCustomerHandler(IOrderingDbContext dbContext)
        : IQueryHandler<GetOrdersByCustomerQuery, GetOrdersByCustomerResult>
    {
        public async Task<GetOrdersByCustomerResult> Handle(GetOrdersByCustomerQuery query, CancellationToken cancellationToken)
        {
            //retrieve from database
            var orders = await dbContext.Orders
                .Include(o => o.OrderItems)
                .AsNoTracking()
                .Where(o => o.CustomerId == CustomerId.Of(query.customerId))
                .OrderBy(o => o.OrderName.Value)
                .ToListAsync(cancellationToken);

            //return converted result
            return new GetOrdersByCustomerResult(orders.ToOrderDtoList());
        }
    }
}
