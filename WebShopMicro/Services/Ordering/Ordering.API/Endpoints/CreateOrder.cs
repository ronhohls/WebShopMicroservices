using Carter;
using Mapster;
using MediatR;
using Ordering.Application.Dtos;
using Ordering.Application.Orders.Commands.CreateOrder;

namespace Ordering.API.Endpoints
{
    //Accepts a CreateOrderRequest object
    //Maps request to a CreateOrderCommand
    //send command to corresponding handler with MediatR
    //return response with created orderId
    public record CreateOrderRequest(OrderDto OrderDto);
    public record CreateOrderResponse(Guid Id);

    public class CreateOrder : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/orders", async (CreateOrderRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateOrderCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateOrderResponse>();

                return Results.Created($"/orders/{response.Id}", response);
            })
            .WithName("CreateOrder")
            .Produces<CreateOrderResponse>(StatusCodes.Status201Created)
            .WithSummary("Create Order")
            .WithDescription("Create Order");
        }
    }
}
