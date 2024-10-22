namespace Ordering.Infrastructure.Data.Extensions
{
    internal class InitialData
    {
        public static IEnumerable<Customer> Customers => new List<Customer>
        {
            Customer.Create(CustomerId.Of(
                new Guid("1a8ab69e-5efb-4575-b59c-41d8d347ef20")),
                "Tom",
                "Tom@gmail.com"),

            Customer.Create(CustomerId.Of(
                new Guid("1689761e-8063-4168-8f45-122ef8e9643a")),
                "John",
                "John@gmail.com")
        };

        public static IEnumerable<Product> Products => new List<Product>
        {
            Product.Create(ProductId.Of(
                new Guid("06f7cbf5-ef04-4db3-b2b3-ac659941016d")),
                "Microsoft Surface Pro 9 5G SQ3 i7 8 GB 128 GB SSD Windows 11 14.4-Inch Laptop, Sapphire",
                23999),

            Product.Create(ProductId.Of(
                new Guid("8244c587-dfb7-4385-bbee-5cc20995137c")),
                "ASUS Vivobook X515EA Intel® Core™ i7-1165G7 8GB 256GB SSD WIN 11Home",
                10999),

            Product.Create(ProductId.Of(
                new Guid("9975e9bc-11cc-4a6b-970a-65d63308ad7b")),
                "ASUS TUF Gaming A15 FA506NF AMD Ryzen™ 5 7535HS 8GB 512GB SSD WIN 11 Home",
                12999),

            Product.Create(ProductId.Of(
                new Guid("6641dfba-ebe9-4723-b1f8-6553191b1fbc")),
                "HP 15s AMD Ryzen 7 5700U 8GB DDR4 512GB SSD 15.6-Inch Full-HD Laptop, Natural Silver",
                10999)
        };

        public static IEnumerable<Order> OrdersWithItems
        {
            get
            {
                var address1 = Address.Of("Tom", "Jones", "tom@gmail.com", "54 Pleasant Street", "South Africa", "Gauteng", "4466");
                var address2 = Address.Of("John", "Goodman", "john@gmail.com", "123 Heavy Street", "South Africa", "Free State", "1365");

                var payment1 = Payment.Of("Tom Jones", "8885762455554444", "11/29", "765", 1);
                var payment2 = Payment.Of("John Goodman", "9655762454864163", "07/30", "469", 2);

                var order1 = Order.CreateOrder(
                    OrderId.Of(Guid.NewGuid()),
                    CustomerId.Of(new Guid("1a8ab69e-5efb-4575-b59c-41d8d347ef20")),
                    OrderName.Of("ORD-1"),
                    shippingAddress: address1,
                    billingAddress: address1,
                    payment1);

                order1.AddProduct(ProductId.Of(new Guid("06f7cbf5-ef04-4db3-b2b3-ac659941016d")), 3, 23999);
                order1.AddProduct(ProductId.Of(new Guid("6641dfba-ebe9-4723-b1f8-6553191b1fbc")), 1, 10999);

                var order2 = Order.CreateOrder(
                    OrderId.Of(Guid.NewGuid()),
                    CustomerId.Of(new Guid("1689761e-8063-4168-8f45-122ef8e9643a")),
                    OrderName.Of("ORD-2"),
                    shippingAddress: address2,
                    billingAddress: address2,
                    payment2);

                order1.AddProduct(ProductId.Of(new Guid("8244c587-dfb7-4385-bbee-5cc20995137c")), 2, 10999);
                order1.AddProduct(ProductId.Of(new Guid("9975e9bc-11cc-4a6b-970a-65d63308ad7b")), 3, 12999);

                return new List<Order> { order1, order2 };
            }
        }


    }
}
