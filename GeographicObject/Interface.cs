public interface IGeographicObject
{
    string GetInfo();
}

public class River_Interface : IGeographicObject
{
    private readonly int X;
    private readonly int Y;
    private readonly string Name;
    private readonly string Description;

    private readonly int FlowSpeed;
    private readonly int Length;

    public River_Interface(int x, int y, string name, string description, int flowSpeed, int length)
    {
        X = x;
        Y = y;
        Name = name;
        Description = description;
        FlowSpeed = flowSpeed;
        Length = length;
    }

    public string GetInfo()
    {
        return $"Name: {Name}, Descriptiom: {Description}, Coordinates: ({X}, {Y}), Flow speed: {FlowSpeed} m/s, Length: {Length} km";
    }
}

public class Mountain_Interface : IGeographicObject
{
    private readonly int X;
    private readonly int Y;
    private readonly string Name;
    private readonly string Description;

    private readonly int HighestPoint;

    public Mountain_Interface(int x, int y, string name, string description, int highestPoint)
    {
        X = x;
        Y = y;
        Name = name;
        Description = description;
        HighestPoint = highestPoint;
    }

    // Реалізація методу GetInfo()
    public string GetInfo()
    {
        return $"Name: {Name}, Descriptiom: {Description}, Coordinates: ({X}, {Y}), Highest point: {HighestPoint} m";
    }
}
class Program
{
    public static void Main()
    {

        IGeographicObject dnister = new River_Interface(25, 45, "Danube", "River that flows along borde", 3, 1362);
        IGeographicObject roman_kosh = new Mountain_Interface(45, 34, "Roman-kosh", "Highest point of Crimea", 1545);

        Console.WriteLine(dnister.GetInfo());
        Console.WriteLine(roman_kosh.GetInfo());
    }
}