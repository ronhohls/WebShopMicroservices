using Basket.API.Dtos;
using MassTransit;

namespace Basket.API.Features.CheckoutBasket
{
    public record CheckoutBasketCommand(BasketCheckoutDto BasketCheckoutDto)
        : ICommand<CheckoutBasketResult>;

    public record CheckoutBasketResult(bool IsSuccess);

    public class CheckoutBasketCommandValidator
        : AbstractValidator<CheckoutBasketCommand>
    {
        public CheckoutBasketCommandValidator()
        {
            RuleFor(x => x.BasketCheckoutDto)
                .NotNull()
                .WithMessage("BasketCheckoutDto cannot be null");

            RuleFor(x => x.BasketCheckoutDto.UserName)
                .NotEmpty()
                .WithMessage("Username is required");
        }
    }
    public class CheckoutBasketHandler(IBasketRepository basketRepository, IPublishEndpoint publishEndpoint)
        : ICommandHandler<CheckoutBasketCommand, CheckoutBasketResult>
    {
        public async Task<CheckoutBasketResult> Handle(CheckoutBasketCommand command, CancellationToken cancellationToken)
        {
            // if existing basket exists, get it with the total price
            //set totalprice on basketcheckout event message
            //send basket checkout event to rabbitmq using masstransit
            //delete the basket

            var basket = await basketRepository.GetBasket(command.BasketCheckoutDto.UserName, cancellationToken);

            if (basket == null)
            {
                return new CheckoutBasketResult(false);
            }

            var eventMessage = command.BasketCheckoutDto.Adapt<BasketCheckoutEvent>();
            eventMessage.TotalPrice = basket.TotalPrice;

            await publishEndpoint.Publish(eventMessage, cancellationToken);

            await basketRepository.DeleteBasket(command.BasketCheckoutDto.UserName, cancellationToken);

            return new CheckoutBasketResult(true);
        }
    }
}
