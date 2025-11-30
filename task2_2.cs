using System.Text;

public abstract class Worker
{
    protected string Name;
    protected string Position;
    protected List<string> WorkDay;
    public Worker (string Name)
    {
        this.Name = Name;
        this.WorkDay = new List<string>();
    }
    public string GetName()
    {
        return Name;
    }
    public string GetPosition()
    {
        return Position;
    }
    public string GetWorkDay()
    {
        if (WorkDay.Count == 0)
        {
            return "No activities recorded.";
        }
        else
        {
            StringBuilder sb = new StringBuilder();
            foreach (var activity in WorkDay)
            {
                sb.Append($"{activity}, ");
            }
            return sb.ToString();
        }
    }
            
    public void Call()
    {
        Console.WriteLine($"{Name} - Call");
        WorkDay.Add("Call");
    }
    public void WriteCode()
    {
        Console.WriteLine($"{Name} - WriteCode");
        WorkDay.Add("WriteCode");
    }
    public void Relax()
    {
        Console.WriteLine($"{Name} - Relax");
        WorkDay.Add("Relax");
    }
    public abstract void FillWorkDay();
}
public class Developer : Worker
{
    public Developer(string Name) : base(Name) { 
        this.Position = "Developer";
    }
    public override void FillWorkDay()
    {
        WriteCode();
        Call();
        Relax();
        WriteCode();
    }
}
public class Manager : Worker
{
    private Random _random = new Random();
    public Manager(string Name) : base(Name) { 
        this.Position = "Manager";
    }
    public override void FillWorkDay()
    {
        for (int i = 0; i < _random.Next(1,11); ++i)
        {
            Call();
        }
        Relax();
        for (int i = 0; i < _random.Next(1,6); ++i)
        {
            Call();
        }
    }
}
class Team
{  
    private string _name;
    private List<Worker> _workers;
    public Team(string name)
    {
        _name = name;
        _workers = new List<Worker>();
    }
    public void AddWorker(Worker worker)
    {
        _workers.Add(worker);
    }
    public void ShowInfo()
    {
        Console.WriteLine("--Short info--");
        Console.WriteLine($"Team: {_name}");
        if (_workers.Count == 0)
        {
            Console.WriteLine("No workers in the team. (not yet)");
            return;
        }
        foreach (var worker in _workers)
        {
            Console.WriteLine($"{worker.GetName()}");
        }
    }
    public void ShowDetailedInfo()
    {
        Console.WriteLine("--Detailed info--");
        Console.WriteLine($"Team: {_name}");
        if (_workers.Count == 0)
        {
            Console.WriteLine("No workers in the team. (not yet)");
            return;
        }
        foreach (var worker in _workers)
        {
            Console.WriteLine($"\n{worker.GetName()} - {worker.GetPosition()} - {worker.GetWorkDay()}");
        }

    }
}

class Program
{
    static void Main(string[] args)
    {
        Team team = new Team("Vibecoders");
        Worker dev1 = new Developer("ChatGPT");
        Worker dev2 = new Developer("Gemini");
        Worker dev3 = new Developer("Claude");
        Worker mgr1 = new Manager("Jamal Negro");
        team.AddWorker(dev1);
        team.AddWorker(dev2);
        team.AddWorker(dev3);
        team.AddWorker(mgr1);
        dev1.FillWorkDay();
        dev2.FillWorkDay();
        dev3.FillWorkDay();
        mgr1.FillWorkDay();
        team.ShowInfo();
        team.ShowDetailedInfo();
    }
}