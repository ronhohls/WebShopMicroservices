﻿namespace Ordering.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderHandler(IOrderingDbContext dbContext)
        : ICommandHandler<CreateOrderCommand, CreateOrderResult>
    {
        public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            //create order entity from command 
            var order = CreateNewOrder(command.OrderDto);

            //Save to database
            dbContext.Orders.Add(order);
            await dbContext.SaveChangesAsync(cancellationToken);

            //return result
            return new CreateOrderResult(order.Id.Value);
        }

        private Order CreateNewOrder(OrderDto orderDto)
        {
            var shippingAddress = Address.Of(
                orderDto.ShippingAddress.FirstName,
                orderDto.ShippingAddress.LastName,
                orderDto.ShippingAddress.EmailAddress,
                orderDto.ShippingAddress.AddressLine,
                orderDto.ShippingAddress.Country,
                orderDto.ShippingAddress.Province,
                orderDto.ShippingAddress.PostalCode
            );

            var billingAddress = Address.Of(
                orderDto.BillingAddress.FirstName,
                orderDto.BillingAddress.LastName,
                orderDto.BillingAddress.EmailAddress,
                orderDto.BillingAddress.AddressLine,
                orderDto.BillingAddress.Country,
                orderDto.BillingAddress.Province,
                orderDto.BillingAddress.PostalCode
            );

            var newOrder = Order.CreateOrder(
                id: OrderId.Of(Guid.NewGuid()),
                customerId: CustomerId.Of(orderDto.CustomerId),
                orderName: OrderName.Of(orderDto.OrderName),
                shippingAddress: shippingAddress,
                billingAddress: billingAddress,
                payment: Payment.Of(
                    orderDto.Payment.CardName,
                    orderDto.Payment.CardNumber,
                    orderDto.Payment.Expiration,
                    orderDto.Payment.CVV,
                    orderDto.Payment.PaymentMethod
                )
            );

            foreach (var orderItemDto in orderDto.OrderItems)
            {
                newOrder.AddProduct(
                    ProductId.Of(orderItemDto.ProductId),
                    orderItemDto.Quantity,
                    orderItemDto.Price
                );
            }

            return newOrder;

        }
    }
}
