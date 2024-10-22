using Carter;
using Mapster;
using MediatR;
using Ordering.Application.Dtos;
using Ordering.Application.Orders.Queries.GetOrdersByCustomer;

namespace Ordering.API.Endpoints
{
    //accepts customerId
    //creates GetOrdersByCustomerQuery and sends it to the corresponding handler
    //returns a list of orders

    public record GetOrdersByCustomerResponse(IEnumerable<OrderDto> Orders);
    public class GetOrdersByCustomer : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders/{customerId}", async (Guid customerId, ISender sender) =>
            {
                var result = await sender.Send(new GetOrdersByCustomerQuery(customerId));

                var response = result.Adapt<GetOrdersByCustomerResponse>();

                return Results.Ok(response);
            })
            .WithName("GetOrdersByCutomer")
            .Produces<GetOrdersByCustomerResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Orders By Cutomer")
            .WithDescription("Get Orders By Cutomer");
        }
    }
}
