namespace WebShopMicro.Web.Models.Catalogue
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string ModelName { get; set; } = default!;
        public string Brand { get; set; } = default!;
        public List<string> Category { get; set; } = new();
        public string Description { get; set; } = default!;
        public string ImageFile { get; set; } = default!;
        public decimal Price { get; set; }

        public IDictionary<string, string> CustomFields { get; set; } = null!;
    }

    //wrapper classes
    public record GetProductsResponse(IEnumerable<ProductModel> Products);
    public record GetProductsByCategoryResponse(IEnumerable<ProductModel> Products);
    public record GetProductByIdResponse(ProductModel Product);
}
