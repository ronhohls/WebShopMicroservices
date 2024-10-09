namespace Catalogue.API.Models
{
    public class Product
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
}
