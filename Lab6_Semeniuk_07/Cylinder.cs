namespace Lab6_Semeniuk_07;

public class Cylinder
{
    public string Material;
    public double Radius;
    public double Height;

    public static int Counter = 0;
    
    public Cylinder(string material, double radius, double height)
    {
        this.Material = material;
        this.Radius = radius;
        this.Height = height;
    }
    
    public Cylinder(string material)
        : this(material, 0, 0)
    {
        Console.WriteLine("The light constructor");
    }


    public double CalculateSurfaceArea()
    {  
        return 2 * Math.PI * this.Radius * (this.Radius + this.Height);
    }

    public void Scale(double factor)
    {  
        if (factor > 0)
        {
            this.Radius *= factor;
            this.Height *= factor;
            return;
        }

        Console.WriteLine("The scale factor isn't valid.");

    }



    public void PrintInfo()
    {
        Console.WriteLine($"Material: {this.Material}");
        Console.WriteLine($"Radius: {this.Radius}");
        Console.WriteLine($"Height: {this.Height}");

    }


}