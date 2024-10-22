using Microsoft.EntityFrameworkCore;

namespace Ordering.Application.Orders.Queries.GetOrdersByName
{
    public class GetOrdersByNameHandler(IOrderingDbContext dbContext)
        : IQueryHandler<GetOrdersByNameQuery, GetOrdersByNameResult>
    {
        public async Task<GetOrdersByNameResult> Handle(GetOrdersByNameQuery query, CancellationToken cancellationToken)
        {
            //retrieve from database
            var orders = await dbContext.Orders
                .Include(o => o.OrderItems)
                .AsNoTracking()
                .Where(o => o.OrderName.Value.Contains(query.Name))
                .OrderBy(o => o.OrderName.Value)
                .ToListAsync(cancellationToken);

            //return converted result
            return new GetOrdersByNameResult(orders.ToOrderDtoList());
        }
    }
}
