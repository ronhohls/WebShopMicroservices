using Refit;

namespace WebShopMicro.Web.Services
{
    public interface IOrderingService
    {
        [Get("/ordering-service/orders?pageNumber={pageNumber}&pageSize={pageSize}")]
        Task<GetOrdersResponse> GetOrders(int? pageNumber = 1, int? pageSize = 10);

        [Get("/ordering-service/orders/{orderName}")]
        Task<GetOrdersByNameResponse> GetOrdersByName(string orderName);

        [Get("/ordering-service/orders/customer/{customerId")]
        Task<GetOrdersByCustomerResponse> GetOrdersByCustomer(Guid customerID);
    }
}
