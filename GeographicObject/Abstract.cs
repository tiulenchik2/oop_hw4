public abstract class GeographicObject
{
    private int X;
    private int Y;
    private string Name;
    private string Description;
    public GeographicObject(int x, int y, string name, string description)
    {
        X = x;
        Y = y;
        Name = name;
        Description = description;
    }
    public virtual string GetInfo()
    {
        return $"Name: {Name}, Description: {Description}, Coordinates: ({X}, {Y})";
    }
}
class River : GeographicObject
{
    private int FlowSpeed;
    private int Length;
    public River(int x, int y, string name, string description, int flowSpeed, int length)
        : base(x, y, name, description)
    {
        FlowSpeed = flowSpeed;
        Length = length;
    }
    public override string GetInfo()
    {
        return base.GetInfo() + $", Flow Speed: {FlowSpeed} m/s, Length: {Length} km";
    }
}
class Mountain : GeographicObject
{
    private int HighestPoint;
    public Mountain(int x, int y, string name, string description, int highpoint, string mountainType)
        : base(x, y, name, description)
    {
        HighestPoint = highpoint;
    }
    public override string GetInfo()
    {
        return base.GetInfo() + $", Highest point: {HighestPoint} m";
    }
}