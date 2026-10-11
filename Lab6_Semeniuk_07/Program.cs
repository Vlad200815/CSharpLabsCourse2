using Lab6_Semeniuk_07;

class Program
{
    static void Main()
    {
        const string divider = "---------------------------------------------------------";
        
        Console.WriteLine(divider);
        Console.WriteLine("Fullname: Vlad Semeniuk");
        Console.WriteLine("Group: IPZ-21");
        Console.WriteLine("Variant: 7");
        Console.WriteLine(divider);
        
        
        Cylinder firstObject = new Cylinder("Сталь", 2.5, 8);
        Cylinder secondObject = new Cylinder("Алюміній", 1.2, 4.5);
        
        
        Console.WriteLine("Initial Objects:");
        
        Console.WriteLine();
        firstObject.PrintInfo();
        Console.WriteLine();
        secondObject.PrintInfo();
        Console.WriteLine(divider);
        
        firstObject.Scale(2.5);
        secondObject.Scale(2.5);
        


        Console.WriteLine("After 2.5 scale:\n");
        
        firstObject.PrintInfo();
        Console.WriteLine($"Surface Area {firstObject.CalculateSurfaceArea():F2}");
        Console.WriteLine();
        secondObject.PrintInfo();
        Console.WriteLine($"Surface Area {secondObject.CalculateSurfaceArea():F2}");
        Console.WriteLine(divider);
         
        Console.WriteLine("Scale only first object:");
        firstObject.Scale(5);
        
        Console.WriteLine();
        firstObject.PrintInfo();
        Console.WriteLine();
        secondObject.PrintInfo();
        Console.WriteLine("The second object didn't change because we create two instances of one class (Cylinder) with new keyword which create a separate instance of a class.");
        Console.WriteLine(divider);
        
        Cylinder testObject = firstObject;
        
        Console.WriteLine("Scale first object together with testObject:");
        firstObject.Scale(5);
        
        Console.WriteLine();
        firstObject.PrintInfo();
        Console.WriteLine();
        testObject.PrintInfo();
        
        Console.WriteLine();
        Console.WriteLine("The state is the same in both objects");
        Console.WriteLine("Because we assign firstObject with = which gives the same link to the same instance of the object and we didn't use new keyword so a new instance was not created.");
        Console.WriteLine(divider);
        
        Console.WriteLine("Individual test: A");
        
        Cylinder firstNewObject = new Cylinder("FirstTestObject");
        Cylinder secondNewObject = new Cylinder("SecondTestObject", 2.2, 3.3);
        
        firstNewObject.PrintInfo();
        Console.WriteLine();
        secondNewObject.PrintInfo();
        Console.WriteLine();
        
        Console.WriteLine("Our C# compiler knows about two constructors and it can decides which one to use");
        Console.WriteLine("If we put only material parameter the compiler will choose the right one");
        Console.WriteLine("Initialization happens it the chosen constructor");
        
    }
}

