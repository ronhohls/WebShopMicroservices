namespace Basket.API.Features.StoreBasket
{
    public record StoreBasketCommmand(ShoppingCart Cart) : ICommand<StoreBasketResult>;
    public record StoreBasketResult(string UserName);

    public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommmand>
    {
        public StoreBasketCommandValidator()
        {
            RuleFor(x => x.Cart)
                .NotNull()
                .WithMessage("Cart cannot be null");

            RuleFor(x => x.Cart.UserName)
                .NotEmpty()
                .WithMessage("Username is required");
        }
    }
    public class StoreBasketCommandHandler(IBasketRepository basketRepository)
        : ICommandHandler<StoreBasketCommmand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommmand command, CancellationToken cancellationToken)
        {

            await basketRepository.StoreBasket(command.Cart, cancellationToken);

            return new StoreBasketResult(command.Cart.UserName);
        }
    }
}
