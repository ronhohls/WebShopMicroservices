using Marten.Schema;

namespace Catalogue.API.Data
{
    public class CatalogueSeedData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            if (await session.Query<Product>().AnyAsync(cancellation))
            {
                return;
            }

            session.Store<Product>(GetSeedProducts());
            
            await session.SaveChangesAsync();

        }

        private static IEnumerable<Product> GetSeedProducts() => new List<Product>()
        {
            new Product()
            {
                Id = new Guid("06f7cbf5-ef04-4db3-b2b3-ac659941016d"),
                Title = "Microsoft Surface Pro 9 5G SQ3 i7 8 GB 128 GB SSD Windows 11 14.4-Inch Laptop, Sapphire",
                ModelName = "Surface Pro 9",
                Brand = "Microsoft",
                Description = "Tablet and Laptop Can be used as a tablet and a laptop\r\nPortable and versatile for work, school or personal use\r\n128 GB storage may be limited for large files\r\nGood option for portability and versatility\r\nUltimate combination of performance and speed",
                ImageFile = "61-McHU8RUL._AC_UL480_FMwebp_QL65_.webp",
                Price = 23999,
                Category = new List<string>{"Laptop"},
                CustomFields = new Dictionary<string, string>
                {
                    { "Screen size", "14.4 Inches" },
                    { "Colour", "Blue" },
                    { "CPU Model", "Intel Core i7" },
                    { "RAM installed", "8 GB" },
                    { "Operating system", "Windows 11" },
                    { "Graphics card", "Integrated" }
                }
            },
            new Product()
            {
                Id = new Guid("8244c587-dfb7-4385-bbee-5cc20995137c"),
                Title = "ASUS Vivobook X515EA Intel® Core™ i7-1165G7 8GB 256GB SSD WIN 11Home",
                ModelName = "Asus Vivobook Go",
                Brand = "Asus",
                Description = "Whether for work or play, ASUS X515 is the entry-level laptop that delivers powerful performance and immersive visuals\r\nIts NanoEdge display (also available as an optional touchscreen) boasts wide 178° viewing angles and a matte anti-glare coating for a truly engaging experience\r\nThere’s also Intel Optane memory support1 to help speed things up even more\r\nInstall apps on the SSD for quicker response and loading times, and use the HDD to store large files such as movies, music libraries, and photo albums",
                ImageFile = "61FO1LGtcOL._AC_UL480_FMwebp_QL65_.webp",
                Price = 10999,
                Category = new List<string>{"Laptop"},
                CustomFields = new Dictionary<string, string>
                {
                    { "Screen size", "15.6 Inches" },
                    { "Colour", "Grey" },
                    { "CPU Model", "Intel Core i7-1165G7" },
                    { "RAM installed", "8 GB" },
                    { "Operating system", "Windows 11 Home" },
                    { "Graphics card", "Integrated" },
                    { "Special features", "Anti Glare Coating, Numeric Keypad" }
                }
            },
            new Product()
            {
                Id = new Guid("9975e9bc-11cc-4a6b-970a-65d63308ad7b"),
                Title = "ASUS TUF Gaming A15 FA506NF AMD Ryzen™ 5 7535HS 8GB 512GB SSD WIN 11 Home",
                ModelName = "ASUS TUF Gaming A15",
                Brand = "Asus",
                Description = "Powerful Performance: Equipped with the AMD Ryzen 5 7535HS processor, the TUF Gaming A15 ensures seamless gameplay and efficient multitasking, handling intensive tasks with ease.\r\nStunning Graphics: Immerse yourself in lifelike visuals with the powerful NVIDIA GeForce GTX graphics card, designed to deliver smooth frame rates and stunning detail.\r\nHigh-Speed Storage: The 512GB SSD provides ample space for your games, applications, and files, ensuring quick load times and fast data access.\r\nOptimal Memory: 8GB of RAM guarantees smooth performance, whether you're gaming, streaming, or working on resource-intensive projects.\r\nWindows 11 Home: Experience the latest features and enhanced security with Windows 11 Home, offering a streamlined interface and improved performance.",
                ImageFile = "71m+cjlJDiL._AC_UL480_FMwebp_QL65_.webp",
                Price = 12999,
                Category = new List<string>{"Laptop", "Gaming Laptop"},
                CustomFields = new Dictionary<string, string>
                {
                    { "Screen size", "15.6 Inches" },
                    { "Colour", "Black" },
                    { "Hard disk size", "512 GB" },
                    { "CPU Model", "Ryzen 5" },
                    { "RAM installed", "8 GB" },
                    { "Operating system", "Windows 11 Home" },
                    { "Graphics card", "Dedicated" },
                    { "Special features", "Backlit Keyboard, Anti Glare Coating, Numeric Keypad" }
                }
            },
            new Product()
            {
                Id = new Guid("6641dfba-ebe9-4723-b1f8-6553191b1fbc"),
                Title = "HP 15s AMD Ryzen 7 5700U 8GB DDR4 512GB SSD 15.6-Inch Full-HD Laptop, Natural Silver",
                ModelName = "HP 15s",
                Brand = "HP",
                Description = "Reliable performance for every day\r\nLong-lasting battery life\r\nThin and light design makes it easy to cary\r\nMicro-edge bezel display\r\nSophisticated and refined design",
                ImageFile = "51u8hwVtZpL._AC_UL480_FMwebp_QL65_ .webp",
                Price = 1,
                Category = new List<string>{"Laptop"},
                CustomFields = new Dictionary<string, string>
                {
                    { "Screen size", "15.6 Inches" },
                    { "Colour", "Natural Silver" },
                    { "Battery cell composition", "Lithium Ion" },
                    { "CPU Model", "AMD Ryzen 7 5700U" },
                    { "RAM installed", "8 GB" },
                    { "Hard disk", "512 GB SSD" },
                    { "Operating system", "Windows 11 Home" },
                    { "Graphics card", "Integrated" }
                }
            },
            new Product()
            {
                Id = new Guid("3bb537a8-ce6a-40fd-a81c-7424b0e20337"),
                Title = "Acer Predator PHN16-71-51J4 Intel Core i5 13500HX 16GB RAM 1TB SSD SlimBezel NVIDIA GeForce RTX 4060 Windows 11 Home 16-Inch Laptop, Black",
                ModelName = "Acer Predator PHN16-71-51J4",
                Brand = "Acer",
                Description = "Features 16GB of RAM for efficient multitasking and 1TB SSD for ample storage space\r\nOffering high-end performance for gaming, content creation and multitasking\r\nPowered by NVIDIA GeForce RTX 4060, capable of running the latest games with high frame rates\r\nA high-refresh-rate display to deliver smooth gameplay",
                ImageFile = "71VrLAwcoIL._AC_UL480_FMwebp_QL65_.webp",
                Price = 24999,
                Category = new List<string>{"Laptop", "Gaming Laptop"},
                CustomFields = new Dictionary<string, string>
                {
                    { "Screen size", "16 Inches" },
                    { "Colour", "Black" },
                    { "CPU Model", "Intel Core i5-13500HX" },
                    { "RAM installed", "16 GB" },
                    { "Operating system", "Windows 11 Home" },
                    { "Graphics card", "Dedicated NVIDIA GeForce RTX 4060" }
                }
            },
            new Product()
            {
                Id = new Guid("eff0088d-cae1-4634-b890-3cd50141430c"),
                Title = "Dell Inspiron 3520 12th Gen Intel Core i3-1215U DDR4 8GB 512GB Intel UHD FHD Windows 11 Home 15.6-Inch Gaming Laptop",
                ModelName = "Inspiron 3520",
                Brand = "Dell",
                Description = "rocessor: Intel Core i3 Adler Lake Six (6) Core i3-1215U Turbo Boost up to 4.4Ghz\r\nOperating System: Windows 11 Home 64-bit\r\nDisplay: 15.6-inch Full HD (1920 x 1080) display\r\nMemory and Storage: 8GB DDR4-3200 SO-Dimm Memory, 512GB SSD Solid State Hard Drive PCIe\r\nOn-board graphics card model: Intel UHD Graphics",
                ImageFile = "511TPkVWRsL._AC_UL480_FMwebp_QL65_.webp",
                Price = 9500,
                Category = new List<string>{"Laptop"},
                CustomFields = new Dictionary<string, string>
                {
                    { "Screen size", "15.6 Inches" },
                    { "Colour", "Black" },
                    { "CPU Model", "Intel Core i3-1215U" },
                    { "RAM installed", "8 GB" },
                    { "Hard disk", "512 GB SSD" },
                    { "Operating system", "Windows 11 Home" },
                    { "Graphics card", "Integrated Intel UHD Graphics" }
                }
            },
            new Product()
            {
                Id = new Guid("5ef62468-6152-4423-a6a6-c5a7bb5c6088"),
                Title = "Samsung Galaxy A35 128GB 5G Dual Sim Smartphone, Blue",
                ModelName = "Galaxy A35",
                Brand = "Samsung",
                Description = "6.6-Inch FHD+ super AMOLED infinity-o display with 120Hz refresh rate\r\nVersatile camera setup with 50MP wide-angle lens and super HDR technology\r\nOcta-core processor with 6GB of RAM for seamless multitasking\r\nGenerous 5000mAh battery for long-lasting usage\r\n5G connectivity for fast and reliable network performance",
                ImageFile = "51kEd-5uhJL._AC_UL480_FMwebp_QL65_.webp",
                Price = 5345,
                Category = new List<string>{"Smartphone"},
                CustomFields = new Dictionary<string, string>
                {
                    { "Screen size", "6.6 Inches" },
                    { "Colour", "Blue" },
                    { "RAM installed", "6 GB" },
                    { "Operating system", "Android" },
                    { "Resolution", "2340 x 1080" },
                    { "Connector type", "USC Type C" },
                    { "Cellular technology", "5G" }
                }
            },
            new Product()
            {
                Id = new Guid("dc610089-8b80-40b1-823d-a68542a40af0"),
                Title = "Xiaomi Redmi 13C 128GB Blue + Powerbank",
                ModelName = "Redmi 13C",
                Brand = "Xiaomi",
                Description = "Smooth 6.74\" 90Hz display.\r\n50MP AI triple camera.\r\nMassive 5000mAh (typ) battery.\r\nSupports 18W fast charging.\r\nUp to 23 hours of video streaming.",
                ImageFile = "51O3U-W9BOL._AC_UL480_FMwebp_QL65_.webp",
                Price = 2989,
                Category = new List<string>{"Smartphone"},
                CustomFields = new Dictionary<string, string>
                {
                    { "Screen size", "9.74 Inches" },
                    { "Colour", "Navy Blue" },
                    { "Storage capacity", "128 GB" },
                    { "Operating system", "Android" },
                    { "Model year", "2023" },
                    { "Cellular technology", "LTE" },
                    { "Item weight", "410 grams" }
                }
            },
            new Product()
            {
                Id = new Guid("02e1c62e-cca8-447a-968c-376525d1973a"),
                Title = "Samsung Galaxy A14 4G 64GB black",
                ModelName = "Galaxy A14 4G",
                Brand = "Samsung",
                Description = "HP03219\r\nItem weight: 200.0 g\r\nModel Number: SM-A145RZKUEUB",
                ImageFile = "71HMXprK79L._AC_UL480_FMwebp_QL65_.webp",
                Price = 3199,
                Category = new List<string>{"Smartphone"},
                CustomFields = new Dictionary<string, string>
                {
                    { "Colour", "Black" },
                    { "CPU Model", "Snapdragon" },
                    { "RAM installed", "4 GB" },
                    { "Storage capacity", "64 GB" },
                    { "Operating system", "Android" },
                    { "Cellular technology", "4G" }
                }
            },
            new Product()
            {
                Id = new Guid("20e024b4-51af-49f1-ba99-96d24121338b"),
                Title = "Hisense H60 Infinity Zoom 6.78 FHD+ 6GB + 128GB 108MP Quad Rear Camera Cellphone - Black",
                ModelName = "H60 Infinity",
                Brand = "Hisense",
                Description = "",
                ImageFile = "51YVX2J1eDL._AC_UL480_FMwebp_QL65_.webp",
                Price = 6588,
                Category = new List<string>{"Smartphone"},
                CustomFields = new Dictionary<string, string>
                {
                    { "Screen size", "6.78 Inches" },
                    { "Colour", "Black" },
                    { "RAM installed", "6 GB" },
                    { "Storage capacity", "128 GB" },
                    { "Operating system", "Android" },
                }
            },
            new Product()
            {
                Id = new Guid("58132d60-fa78-4b08-8538-ac32d53be438"),
                Title = "Oppo A40M 6GB 256GB Android Smartphone, Starlight White",
                ModelName = "A40M",
                Brand = "Oppo",
                Description = "Military-grade shock resistance\r\nMultiple liquid resistance\r\n1000 Nit ultra bright display\r\n45W supervooctm flash charge\r\n6GB RAM and 256GB internal storage",
                ImageFile = "71hZxrvFfML._AC_UL480_FMwebp_QL65_.webp",
                Price = 4844,
                Category = new List<string>{"Smartphone"},
                CustomFields = new Dictionary<string, string>
                {
                    { "Screen size", "66.7 Inches" },
                    { "Colour", "Starlight White" },
                    { "RAM installed", "6 GB" },
                    { "Storage capacity", "256 GB" },
                    { "Operating system", "ColorOS 14.0" },
                    { "Resolution", "1080 x 750" },
                    { "Refresh rate", "90 Hz" },
                    { "Cellular technology", "4G" }
                }
            },
            new Product()
            {
                Id = new Guid("0f91e08f-a32b-4f94-833b-b707a139ce72"),
                Title = "Hisense H60 Infinity Lite 6.95\" FHD+ 4GB + 128GB 48MP Quad Rear Camera Cellphone - Blue with Hisense Bluetooth Earphones (Blue)",
                ModelName = "H60 Infinity Lite",
                Brand = "Hisense",
                Description = "",
                ImageFile = "51IFmP4rALL._AC_UL480_FMwebp_QL65_.webp",
                Price = 4588,
                Category = new List<string>{"Smartphone"},
                CustomFields = new Dictionary<string, string>
                {
                    { "Screen size", "6.95 Inches" },
                    { "Colour", "Blue" },
                    { "RAM installed", "4 GB" },
                    { "Storage capacity", "128 GB" }
                }
            },
            new Product()
            {
                Id = new Guid("51898e73-53da-4f33-8517-c3eea7eda22f"),
                Title = "Tecno Spark 10 Pro Dual Sim 256GB - Pearl White",
                ModelName = "Spark 10 Pro",
                Brand = "Techno",
                Description = "Segment First 16GB RAM + 128GB ROM for maximum performance\r\nUltra clear 50MP intelligent dual rear imaging system\r\nMega 5000mAh Battery with 18W Flash Charger for long lasting backup\r\n32MP Segment Leading Selfie camera for capturing and sharing stunning photos and videos",
                ImageFile = "618h8sawi2L._AC_UL480_FMwebp_QL65_.webp",
                Price = 5853.96M,
                Category = new List<string>{"Smartphone"},
                CustomFields = new Dictionary<string, string>
                {
                    { "Screen size", "6.8 Inches" },
                    { "Colour", "Pearl White" },
                    { "Storage capacity", "256 GB" },
                    { "Operating system", "Android" },
                    { "CPU Model", "Snapdragon" },
                    { "Model year", "2023" }
                }
            },
            new Product()
            {
                Id = new Guid("41d60bb6-9a6e-48cf-8a55-0a420f9f9685"),
                Title = "Vivo Y36 RAM 8GB ROM 256GB Glitter Aqua (V2247)",
                ModelName = "Y36",
                Brand = "Vivo",
                Description = "",
                ImageFile = "51fplw7aX5L._AC_UL480_FMwebp_QL65_.webp",
                Price = 7599,
                Category = new List<string>{"Smartphone"},
                CustomFields = new Dictionary<string, string>
                {
                    { "Screen size", "15.6 Inches" },
                    { "Colour", "Glitter Aqua" },
                    { "RAM installed", "8 GB" },
                    { "Storage capacity", "256 GB" },
                    { "Battery", "5000 mAh (TYP)" },
                    { "Special features", "Fast charging 44W" }
                }
            },
            new Product()
            {
                Id = new Guid("08499561-b356-4bc2-80ad-e561d14dd9c1"),
                Title = "JBL Flip 6 Portable Bluetooth Speaker, Black",
                ModelName = "Flip 6",
                Brand = "JBL",
                Description = "Louder, more powerful sound: The beat goes on with the JBL Flip 6 2-way speaker system, engineered to deliver loud, crystal clear, powerful sound. Its racetrack-shaped woofer delivers exceptional low frequencies and midrange, while a separate tweeter produces crisp, clear high-frequencies. Flip 6 also features optimized dual passive radiators for deep bass, fine-tuned with using Harman’s advanced algorithm.\r\nIP67 waterproof and dustproof: To the pool. To the park. JBL Flip 6 is IP67 waterproof and dustproof, so you can bring your speaker anywhere.\r\n12 Hours of Playtime: Don’t sweat the small stuff like charging your battery. JBL Flip 6 gives you up to 12 hours of playtime on a single charge.\r\nCrank up the fun with PartyBoost: PartyBoost allows you to pair two JBL PartyBoost-compatible speakers together for stereo sound or link multiple JBL PartyBoost-compatible speakers to truly pump up your party.\r\nUSB charging protection: Power up with peace of mind. The JBL Flip 6 offers USB-C charging protection. That means a reminder sound will alert you to unplug if the connector detects water, salt, or any other chemicals.",
                ImageFile = "71zDU8JBLZL._AC_UL480_FMwebp_QL65_.webp",
                Price = 2199,
                Category = new List<string>{"Bluetooth speaker"},
                CustomFields = new Dictionary<string, string>
                {
                    { "Speaker maximum output power", "30 Watts" },
                    { "Colour", "Black" },
                    { "Frequency response", "60 Hz" },
                    { "Audio output mode", "Stereo" },
                    { "Mounting type", "Freestanding speaker" },
                    { "Speaker type", "Multimedia" },
                    { "Special features", "Portable" }
                }
            },
            new Product()
            {
                Id = new Guid("7b423f55-f100-45a6-b039-484bcfdaa47a"),
                Title = "JBL Go 4 Portable Bluetooth Speaker, Black",
                ModelName = "Go 4",
                Brand = "JBL",
                Description = "Ultra-portable JBL Pro Sound with punchier bass: Don’t let its little size fool you. The JBL Go 4 packs a serious musical punch, delivering big JBL Pro Sound with punchy bass. Your friends won’t believe how much great JBL Pro Sound comes out of such a small speaker.\r\nUp to 7 hours of playtime plus 2 hours with Playtime Boost: Don’t sweat the small stuff like charging your battery. JBL Go 4 gives you up to 7 hours of playtime on a single charge. Simply tap Playtime Boost to prolong the playtime, adding up to 2 hours to your battery life. It tunes and optimizes the performance for louder and crisper sound.\r\nWaterproof and dustproof: The JBL Go 4’s IP67 waterproof and dustproof rating ensures this portable speaker can handle almost any environment, from a poolside party to a seaside picnic.\r\nMulti-speaker connection by Auracast: Want even bigger JBL Pro Sound? Pair two Go4s for stereo sound, or wirelessly connect multiple JBL Auracast-enabled speakers using Auracast for even bigger sound.\r\nMade in part with recycled materials: The JBL Go 4 incorporates post-consumer recycled plastic and fabric for the speaker grille. It’s also packaged in FSCcertified paper printed with soy ink.",
                ImageFile = "71E9GeEQE0L._AC_UL480_FMwebp_QL65_.webp",
                Price = 899,
                Category = new List<string>{"Bluetooth speaker"},
                CustomFields = new Dictionary<string, string>
                {
                    { "Speaker maximum output power", "4 Watts" },
                    { "Colour", "Black" },
                    { "Connectivity technology", "Bluetooth" },
                    { "Audio output mode", "Stereo" },
                    { "Mounting type", "Tabletop" },
                    { "Speaker type", "Outdoor" }
                }
            },
            new Product()
            {
                Id = new Guid("40f9fff7-4e76-4066-bc01-4fd5a971776e"),
                Title = "Volkano Stun Series Bluetooth Speaker, Black",
                ModelName = "Stun Series",
                Brand = "Volkano",
                Description = "Lightweight and portable fabric Bluetooth speaker\r\nConnect through Bluetooth or aux\r\nMicro-USB charging cable\r\nPlay your music from a microSD card with the built-in card reader\r\nSoft silicone-finished buttons and carry strap",
                ImageFile = "71+mwjZpgsL._AC_UL480_FMwebp_QL65_.webp",
                Price = 249,
                Category = new List<string>{"Blutooth speaker"},
                CustomFields = new Dictionary<string, string>
                {
                    { "Speaker maximum output power", "10 Watts" },
                    { "Colour", "Black" },
                    { "Frequency response", "120 Hz" },
                    { "Connectivity technology", "Bluetooth, Auxiliary, USB" },
                    { "Audio output mode", "Stereo" },
                    { "Mounting type", "Speaker" },
                    { "Special features", "Auxiliary Input, SD Card Input, USB Input, FM Radio, Bluetooth, Built-in Microphone and Speakerphone, Carry Handle, 10 W Peak Power" }
                }
            },
            new Product()
            {
                Id = new Guid("e3f0c07f-0fd7-45c5-94f4-9d06335a3d7f"),
                Title = "Sony SRS-XB100/BC Portable Bluetooth Wireless Speaker, Black",
                ModelName = "SRS-XB100/BC",
                Brand = "Sony",
                Description = "Enjoy powerful sound with extra bass and sound diffusion processor\r\n16 Hours of battery life and new battery life indicator\r\nWaterproof and dustproof with ip67 rating\r\nCrafted from premium materials to be comfortable and lightweight\r\nSuitable for listen to music at home or go out and have fun with friends",
                ImageFile = "71g5TAy0SJL._AC_UL480_FMwebp_QL65_.webp",
                Price = 1199,
                Category = new List<string>{"Bluetooth speaker"},
                CustomFields = new Dictionary<string, string>
                {
                    { "Connectivity technology", "Bluetooth" },
                    { "Colour", "Black" },
                    { "Audio output mode", "Mono" },
                    { "Mounting type", "Shelf Mount" },
                    { "Speaker type", "Subwoofer" },
                    { "Special features", "Portable" }
                }
            },
            new Product()
            {
                Id = new Guid("f4e0f796-cd00-49ea-82ed-f55865dcf154"),
                Title = "Volkano Bazooka Series Bluetooth True Wireless Speaker, Black",
                ModelName = "Bazooka series",
                Brand = "Volkano",
                Description = "Original Volkano Bluetooth speaker, still a top seller\r\nExplosive bass and scorching sound in a small size\r\nIntegrated playback and volume controls\r\nLightweight and portable with a carry strap",
                ImageFile = "41bkY43jgqL._AC_UL480_FMwebp_QL65_.webp",
                Price = 499,
                Category = new List<string>{"Bluetooth speaker"},
                CustomFields = new Dictionary<string, string>
                {
                    { "Connectivity technology", "Bluetooth" },
                    { "Colour", "Black" },
                    { "Included components", "1 x Volkano Bazooka Series Bluetooth True Wireless Speaker, Black" },
                    { "Product dimensions", "15D x 15W x 15H centimetres" },
                    { "Speaker type", "Multimedia" }
                }
            },
            new Product()
            {
                Id = new Guid("f1191d8a-b0b8-4edd-8e04-6fed0702ab82"),
                Title = "JBL Pulse 5 Portable Bluetooth Speaker, Black",
                ModelName = "Pulse 5",
                Brand = "JBL",
                Description = "Eye-catching 360-degree light show: Brighten your nights with 360 degrees of eye-catching colors synced to the beat of your favourite songs. Or match your mood by customizing the bigger, bolder lightshow on the Pulse 5's expanded transparent outer body using the JBL Portable app.\r\nBold sound and deep bass in all directions: You'll enjoy pure, bold JBL Original Pro Sound in all directions with its separate tweeter and upfiring driver, while the passive radiator on the bottom of the speaker delivers deep bass—so you can truly feel the music.\r\nIP67 dustproof and waterproof: To the pool. To the park. JBL Pulse 5 is IP67 waterproof and dustproof, so you can bring your speaker anywhere.\r\n12 hours of play time: Highlight the moment, day or night, with up to 12 hours of battery life from a single charge\r\nWireless Bluetooth streaming: Wirelessly connect up to 2 smartphones or tablets to the speaker and take turns enjoying JBL Original Pro sound.",
                ImageFile = "4143G5y+x2L._AC_UL480_FMwebp_QL65_.webp",
                Price = 5489,
                Category = new List<string>{"Bluetooth speaker"},
                CustomFields = new Dictionary<string, string>
                {
                    { "Speaker maximum output power", "40 Watts" },
                    { "Connectivity technology", "Bluetooth" },
                    { "Colour", "Black" },
                    { "Audio output mode", "Stereo" },
                    { "Input voltage", "5 Volts" },
                    { "Mounting type", "Shelf mount" },
                    { "Special features", "Waterproof, Dustproof" }
                }
            },
        };
    }
}
