namespace WebShopMicro.Web.Models.Basket
{
    public class BasketCheckoutModel
    {
        //user info
        public string UserName { get; set; } = default!;
        public Guid CustomerId { get; set; } = default!;
        public decimal TotalPrice { get; set; } = default!;

        //shipping and billing addresses
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string EmailAddress { get; set; } = default!;
        public string AddressLine { get; set; } = default!;
        public string Country { get; set; } = default!;
        public string Province { get; set; } = default!;
        public string PostalCode { get; set; } = default!;

        //payment
        public string CardName { get; set; } = default!;
        public string CardNumber { get; set; } = default!;
        public string Expiration { get; set; } = default!;
        public string CVV { get; set; } = default!;
        public int PaymentMethod { get; set; } = default;

    }

    //wrapper classes
    public record CheckoutBasketRequest(BasketCheckoutModel BasketCheckoutModel);
    public record CheckoutBasketResponse(bool IsSuccess);
}
