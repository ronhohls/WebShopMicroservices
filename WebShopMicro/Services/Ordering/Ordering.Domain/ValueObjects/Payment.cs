using System.Diagnostics.Metrics;
using System.Net.Mail;

namespace Ordering.Domain.ValueObjects
{
    public record Payment
    {
        public string? CardName { get; } = default!;
        public string CardNumber { get; } = default!;
        public string Expiration { get; } = default!;
        public string CVV { get; } = default!;
        public int PaymentMethod { get; } = default!;

        //default constructor, required for EF Core
        protected Payment()
        {
        }

        //private constructor
        private Payment(string cardName, string cardNumber, string expiration, string cvv, int paymentMethod)
        {
            CardName = cardName;
            CardNumber = cardNumber;
            Expiration = expiration;
            CVV = cvv;
            PaymentMethod = paymentMethod;
        }

        //static create method
        public static Payment Of(string cardName, string cardNumber, string expiration, string cvv, int paymentMethod)
        {
            //validation
            ArgumentException.ThrowIfNullOrWhiteSpace(cardName);
            ArgumentException.ThrowIfNullOrWhiteSpace(cardNumber);
            ArgumentException.ThrowIfNullOrWhiteSpace(cvv);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(cvv.Length, 3);

            return new Payment(cardName, cardNumber, expiration, cvv, paymentMethod);
        }
    }
}
