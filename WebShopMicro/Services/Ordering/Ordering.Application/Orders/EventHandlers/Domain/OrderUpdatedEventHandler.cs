using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Domain.Abstractions;

namespace Ordering.Application.Orders.EventHandlers.Domain
{
    public class OrderUpdatedEventHandler(ILogger<OrderUpdatedEventHandler> logger)
        : INotificationHandler<OrderUpdatedEvent>
    {
        public Task Handle(OrderUpdatedEvent domainEvent, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain event handled: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
