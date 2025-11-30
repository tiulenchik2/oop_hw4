namespace hw4_1_maui.Models
{
    public class Book : Product
    {
        public int PageCount { get; set; }
        public string Publisher { get; set; }
        public List<string> Authors { get; set; }
        public Book(decimal price, string country, string name, DateTime packagedate, string desc, int pageCount, string publisher, List<string> authors)
            : base(price, country, name, packagedate, desc)
        {
            PageCount = pageCount;
            Publisher = publisher;
            Authors = authors ?? new List<string>();
        }
    }
}