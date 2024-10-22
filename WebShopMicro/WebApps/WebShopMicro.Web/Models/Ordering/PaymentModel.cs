namespace WebShopMicro.Web.Models.Ordering
{
    public record PaymentModel(
        string CardName,
        string CardNumber,
        string Expiration,
        string CVV,
        int PaymentMethod);
}
