using Refit;

namespace WebShopMicro.Web.Services
{
    public interface ICatalogueService
    {
        [Get("/catalogue-service/products?pageNumber={pageNumber}&pageSize={pageSize}")]
        Task<GetProductsResponse> GetProducts(int? pageNumber = 1, int? pageSize = 10);

        [Post("/catalogue-service/products/{id}")]
        Task<GetProductByIdResponse> GetProductById(Guid id);

        [Delete("/catalogue-service/products/category/{category")]
        Task<GetProductsByCategoryResponse> GetProductsByCategory(string category);
    }
}
