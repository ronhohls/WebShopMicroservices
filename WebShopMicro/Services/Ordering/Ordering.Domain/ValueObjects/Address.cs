namespace Ordering.Domain.ValueObjects
{
    public record Address
    {
        public string FirstName { get; } = default!;
        public string LastName { get; } = default!;
        public string? EmailAddress { get; } = default!;
        public string AddressLine { get; } = default!;
        public string Country { get; } = default!;
        public string Province { get; } = default!;
        public string PostalCode { get; } = default!;

        //default constructor, required for EF Core
        protected Address()
        {
        }

        //private constructor
        private Address(string firstName, string lastName, string emailAddress, string addressLine, string country, string province, string postalCode)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            AddressLine = addressLine;
            Country = country;
            Province = province;
            PostalCode = postalCode;
        }

        //static create method
        public static Address Of(string firstName, string lastName, string emailAddress, string addressLine, string country, string province, string postalCode)
        {
            //validation
            ArgumentException.ThrowIfNullOrWhiteSpace(emailAddress);
            ArgumentException.ThrowIfNullOrWhiteSpace(addressLine);

            return new Address(firstName, lastName, emailAddress, addressLine, country, province, postalCode);
        }
    }
}
