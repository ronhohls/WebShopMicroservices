namespace Ordering.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderHandler(IOrderingDbContext dbContext)
        : ICommandHandler<UpdateOrderCommand, UpdateOrderResult>
    {
        public async Task<UpdateOrderResult> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            //get order id from command 
            var orderId = OrderId.Of(command.OrderDto.Id);
            //retrieve order from database
            var order = await dbContext.Orders
                .FindAsync([orderId], cancellationToken: cancellationToken);

            //check if found
            if (order is null)
            {
                throw new OrderNotFoundException(command.OrderDto.Id);
            }
            //update order entry

            UpdateOrder(order, command.OrderDto);

            //save to database
            dbContext.Orders.Update(order);
            await dbContext.SaveChangesAsync(cancellationToken);

            //return result
            return new UpdateOrderResult(true);
        }

        private void UpdateOrder(Order order, OrderDto orderDto)
        {
            var updatedShippingAddress = Address.Of(
                orderDto.ShippingAddress.FirstName,
                orderDto.ShippingAddress.LastName,
                orderDto.ShippingAddress.EmailAddress,
                orderDto.ShippingAddress.AddressLine,
                orderDto.ShippingAddress.Country,
                orderDto.ShippingAddress.Province,
                orderDto.ShippingAddress.PostalCode
            );

            var updatedBillingAddress = Address.Of(
                orderDto.BillingAddress.FirstName,
                orderDto.BillingAddress.LastName,
                orderDto.BillingAddress.EmailAddress,
                orderDto.BillingAddress.AddressLine,
                orderDto.BillingAddress.Country,
                orderDto.BillingAddress.Province,
                orderDto.BillingAddress.PostalCode
            );

            var updatedPayment = Payment.Of(
                orderDto.Payment.CardName,
                orderDto.Payment.CardNumber,
                orderDto.Payment.Expiration,
                orderDto.Payment.CVV,
                orderDto.Payment.PaymentMethod
            );

            order.UpdateOrder(
                orderName: OrderName.Of(orderDto.OrderName),
                shippingAddress: updatedShippingAddress,
                billingAddress: updatedBillingAddress,
                payment: updatedPayment,
                orderStatus: orderDto.OrderStatus
            );
        }
    }
}
