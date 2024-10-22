namespace Ordering.Domain.ValueObjects
{
    public record OrderName
    {
        //constraint
        private const int DefaultLength = 5;
        public string Value { get; }
        private OrderName(string value) => Value = value;

        //static create method
        public static OrderName Of(string value)
        {
            //validation
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            ArgumentOutOfRangeException.ThrowIfNotEqual(value.Length, DefaultLength);

            return new OrderName(value);
        }
    }
}
