namespace hw4_1_maui.Models
{
    public class Product
    {
        public decimal Price { get; set; }
        public string CountryOrigin { get; set; }
        public string Name { get; set; }
        public DateTime PackagingDate { get; set; }
        public string Description { get; set; }

        public Product(decimal price, string country, string name, DateTime packagedate, string desc)
        {
            Price = price;
            CountryOrigin = country;
            Name = name;
            packagedate = PackagingDate;
            Description = desc;
        }
    }
}