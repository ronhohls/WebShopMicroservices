using Discount.Grpc;

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
    public class StoreBasketCommandHandler
        (IBasketRepository basketRepository, DiscountProtoService.DiscountProtoServiceClient discountProto)
        : ICommandHandler<StoreBasketCommmand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommmand command, CancellationToken cancellationToken)
        {
            await DeductDiscount(command.Cart, cancellationToken);

            await basketRepository.StoreBasket(command.Cart, cancellationToken);

            return new StoreBasketResult(command.Cart.UserName);
        }
        private async Task DeductDiscount(ShoppingCart cart, CancellationToken cancellationToken)
        {
            foreach (var item in cart.Items)
            {
                var coupon = await discountProto.GetDiscountAsync(
                    new GetDiscountRequest { ProductName = item.ProductName }, cancellationToken: cancellationToken);
                item.Price -= coupon.Amount;
            }
        }
    }
}
