using Common.Messaging.Events;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Orders.Commands.CreateOrder;

namespace Ordering.Application.Orders.EventHandlers.Integration
{
    public class BasketCheckoutEventHandler
        (ISender sender, ILogger<BasketCheckoutEventHandler> logger)
        : IConsumer<BasketCheckoutEvent>
    {
        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            //create new order and start order fulfillment
            logger.LogInformation("Integration event handled: {IntegrationEvent}", context.Message.GetType().Name);

            var command = MapToCreateOrderCommand(context.Message);
            await sender.Send(command);

            throw new NotImplementedException();
        }

        private CreateOrderCommand MapToCreateOrderCommand(BasketCheckoutEvent message)
        {
            //create order with event data
            var addressDto = new AddressDto(
                message.FirstName,
                message.LastName,
                message.EmailAddress,
                message.AddressLine,
                message.Country,
                message.Province,
                message.PostalCode);

            var paymentDto = new PaymentDto(
                message.CardName,
                message.CardNumber,
                message.Expiration,
                message.CVV,
                message.PaymentMethod);

            var orderId = Guid.NewGuid();

            var orderDto = new OrderDto(
                Id: orderId,
                CustomerId: message.CustomerId,
                OrderName: message.UserName,
                ShippingAddress: addressDto,
                BillingAddress: addressDto,
                Payment: paymentDto,
                OrderStatus: Ordering.Domain.Enums.OrderStatus.Pending,
                OrderItems:
                [
                    new OrderItemDto(orderId, new Guid("06f7cbf5-ef04-4db3-b2b3-ac659941016d"),2, 23999),
                    new OrderItemDto(orderId, new Guid("8244c587-dfb7-4385-bbee-5cc20995137c"),1, 10999)
                ]);

            return new CreateOrderCommand(orderDto);
        }
    }
}
