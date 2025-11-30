using System.Text;

class Converter
{
    private decimal usdRate;
    private decimal eurRate;
    public Converter(decimal usdRate, decimal eurRate)
    {
        this.usdRate = usdRate;
        this.eurRate = eurRate;
    }
    public decimal UahToUsd(decimal uah)
    {
        return uah / usdRate;
    }
    public decimal UahToEur(decimal uah)
    {
        return uah / eurRate;
    }
    public decimal UsdToUah(decimal usd)
    {
        return usd * usdRate;
    }
    public decimal EurToUah(decimal eur)
    {
        return eur * eurRate;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Converter converter = new Converter(42.19m, 48.87m);
        decimal uahAmount = 1000m;
        decimal usdAmount = converter.UahToUsd(uahAmount);
        decimal eurAmount = converter.UahToEur(uahAmount);
        Console.WriteLine($"{uahAmount} UAH is {usdAmount:F2} USD");
        Console.WriteLine($"{uahAmount} UAH is {eurAmount:F2} EUR");
        decimal backToUahFromUsd = converter.UsdToUah(usdAmount);
        decimal backToUahFromEur = converter.EurToUah(eurAmount);
        Console.WriteLine($"{usdAmount:F2} USD is {backToUahFromUsd:F2} UAH");
        Console.WriteLine($"{eurAmount:F2} EUR is {backToUahFromEur:F2} UAH");
    }
}