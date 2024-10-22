using WebShopMicro.Web.Models.Ordering.Enums;

namespace WebShopMicro.Web.Models.Ordering
{
    public record OrderModel(
        Guid Id,
        Guid CustomerId,
        string OrderName,
        AddressModel ShippingAddress,
        AddressModel BillingAddress,
        PaymentModel Payment,
        OrderStatus OrderStatus,
        List<OrderItemModel> OrderItems);

    //wrapper classes
    public record GetOrdersResponse(PaginatedResult<OrderModel> Orders);
    public record GetOrdersByNameResponse(IEnumerable<OrderModel> Orders);
    public record GetOrdersByCustomerResponse(IEnumerable<OrderModel> Orders);
}
