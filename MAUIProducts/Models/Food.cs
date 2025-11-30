namespace hw4_1_maui.Models
{
    public class Food : Product
    {
        public int ExpirationDays { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public Food(decimal price, string country, string name, DateTime packagedate, string desc, int expirationDays, double quantity, string unit)
            : base(price, country, name, packagedate, desc)
        {
            ExpirationDays = expirationDays;
            Quantity = quantity;
            Unit = unit;
        }
    }
}
