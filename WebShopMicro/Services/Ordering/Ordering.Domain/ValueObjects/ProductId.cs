namespace Ordering.Domain.ValueObjects
{
    public record ProductId
    {
        public Guid Value { get; }
        private ProductId(Guid value) => Value = value;

        //static create method
        public static ProductId Of(Guid value)
        {
            //validation
            ArgumentNullException.ThrowIfNull(value);

            if (value == Guid.Empty)
            {
                throw new DomainException("ProductId cannot be empty");
            }

            return new ProductId(value);
        }
    }
}
