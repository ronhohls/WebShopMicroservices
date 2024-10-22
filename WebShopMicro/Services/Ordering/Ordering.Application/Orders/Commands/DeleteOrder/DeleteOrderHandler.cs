namespace Ordering.Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderHandler(IOrderingDbContext dbContext)
        : ICommandHandler<DeleteOrderCommand, DeleteOrderResult>
    {
        public async Task<DeleteOrderResult> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            //get orderId from command
            var orderId = OrderId.Of(command.OrderId);
            //retrieve order from database
            var order = await dbContext.Orders
                .FindAsync([orderId], cancellationToken: cancellationToken);

            if (order is null)
            {
                throw new OrderNotFoundException(command.OrderId);
            }

            //delete from database
            dbContext.Orders.Remove(order);
            await dbContext.SaveChangesAsync(cancellationToken);

            //return result
            return new DeleteOrderResult(true);
        }
    }
}
