namespace Catalogue.API.Products.UpdateProduct
{
    public record UpdateProductCommand(Guid Id, string Title, string ModelName, string Brand, List<string> Category, string Description, string ImageFile, decimal Price, Dictionary<string, string> CustomFields)
        :ICommand<UpdateProductResult>;

    public record UpdateProductResult(bool IsSuccess);

    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Product ID is required");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .Length(2, 150).WithMessage("Title must be between 2 and 150 characters");

            RuleFor(x => x.ModelName)
                .NotEmpty().WithMessage("Model name is required");

            RuleFor(x => x.Brand)
                .NotEmpty().WithMessage("Brand is required");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
    internal class UpdateProductHandler(IDocumentSession session)
        : ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

            if (product is null)
            {
                throw new ProductNotFoundException(command.Id);
            }

            product.Title = command.Title;
            product.ModelName = command.ModelName;
            product.Brand = command.Brand;
            product.Category = command.Category;    
            product.Description = command.Description;
            product.ImageFile = command.ImageFile;
            product.Price = command.Price;  
            product.CustomFields = command.CustomFields;

            session.Update(product);
            await session.SaveChangesAsync(cancellationToken);

            return new UpdateProductResult(true);
        }
    }
}
