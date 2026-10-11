using Lab7Library.Calculations;
using Lab7Library.TextProcessing;
using Lab7Library.Common;


class Program
{
    static void Main()
    {
        const string divider = "--------------------------------------------------------------------------------------";
        
        double radius = 8;
        double height = 5;

        double volume = MathTools.CalculateCylinderVolume(radius, height);
        
        
        Console.WriteLine(divider);
        Console.WriteLine("Fullname: Vlad Semeniuk");
        Console.WriteLine("Group: IPZ-21");
        Console.WriteLine("Variant: 7");
        Console.WriteLine(divider);
        
        if (double.IsNaN(volume))
        {
            Console.WriteLine("Radius and height are invalid");
        }
        else
        {
            Console.WriteLine(
                $"Radius: {radius:F2}, height: {height:F2}");
            Console.WriteLine($"Cylinder volume: {volume:F2}");
        }
        
        Console.WriteLine(divider); 
        
        Console.WriteLine();
        string text1 = "C# Class Library for the 7th variant";
        string text2 = "Hello 12 my na55me is Vla5d and I am a flutter developer#1";
        
        // Full path name works even without using keyword.
        string shotText =
            Lab7Library.TextProcessing.TextTools
                .ReplaceDigitsWithAsterisk(text1);
        
        
        // With using we could use shorter variant of calling TextTools methods.
        string longText = TextTools.ReplaceDigitsWithAsterisk(text2);
        
        
        
        Console.WriteLine($"Text 1: {shotText}");
        Console.WriteLine($"Text 2: {longText}");
        
        
        Random random = new Random();
        double randomNum = random.Next();
        Console.WriteLine($"Random number: {randomNum}");
        // bool isPositive = ValidationTools.IsPositive(randomNum);
        Console.WriteLine($"Here is the error:\nProgram.cs(56,27): Error CS0122 : 'ValidationTools' is inaccessible due to its protection level\n Finished building project: Lab7App. Succeeded: False. Errors: 1. Warnings: 0");
        Console.WriteLine();
        Console.WriteLine("We can use classes with internal modifier even if we set up reference and using.");
        Console.WriteLine("We can use it only inside that project where it was created.");
        Console.WriteLine(divider); 

    }
}

