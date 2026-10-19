namespace Lab11Models;

public class StatusReporter
{
    public string Lable { get; }

    public StatusReporter(string label)
    {
        Lable = label;
    }

    public void PrintShort(int value)
    {
        Console.WriteLine($"Value: {value}");
    }


    public void PrintDetailed(int value)
    {
        Console.WriteLine($"Threshold was reached on the value: {value}");
    }
    
}