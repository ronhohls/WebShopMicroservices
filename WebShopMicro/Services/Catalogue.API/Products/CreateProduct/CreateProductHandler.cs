namespace Catalogue.API.Products.CreateProduct
{
    public record CreateProductCommand(string Title, string ModelName, string Brand, List<string> Category, string Description, string ImageFile, decimal Price, Dictionary<string, string> CustomFields)
        : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title is required")
                .Length(2, 150)
                .WithMessage("Title must be between 2 and 150 characters");

            RuleFor(x => x.ModelName)
                .NotEmpty()
                .WithMessage("Model name is required");

            RuleFor(x => x.Brand)
                .NotEmpty()
                .WithMessage("Brand is required");

            RuleFor(x => x.Category)
                .NotEmpty()
                .WithMessage("Category is required");

            RuleFor(x => x.ImageFile)
                .NotEmpty()
                .WithMessage("Image File is required");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("Price must be greater than 0");
        }
    }
    internal class CreateProductCommandHandler(IDocumentSession session) 
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //create product entity from command object
            var product = new Product
            {
                Title = command.Title,
                ModelName = command.ModelName,
                Brand = command.Brand,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,
                CustomFields = command.CustomFields
            };
            //save database
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            //return CreateProductResult result
            return new CreateProductResult(product.Id);
        }
    }
}
