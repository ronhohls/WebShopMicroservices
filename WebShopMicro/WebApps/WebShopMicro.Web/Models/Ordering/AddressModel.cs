namespace WebShopMicro.Web.Models.Ordering
{
    public record AddressModel(
        string FirstName,
        string LastName,
        string EmailAddress,
        string AddressLine,
        string Country,
        string Province,
        string PostalCode);
}
