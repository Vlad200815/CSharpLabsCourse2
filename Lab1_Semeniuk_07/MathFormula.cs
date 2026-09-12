namespace Lab1_Semeniuk_07;

public static class MathFormula
{
    /// <summary>
    /// Solve the 7th expression 
    /// </summary>
    public static void SolveExpression()
    {
        Console.WriteLine("Formula");
        
        Console.Write("Enter x: ");
        // Check for a valid input and convert to double for calculation
        if (!double.TryParse(Console.ReadLine(), out double x)) Console.WriteLine("X is not a number.\n");
        
        Console.Write("Enter z: ");
        // Check for a valid input and convert to double for calculation
        if (!double.TryParse(Console.ReadLine(), out double z)) Console.WriteLine("Z is not a number.\n");
        
        
        // Prints out user's values
        Console.WriteLine("-------------------------");
        Console.WriteLine($"X = {x}");
        Console.WriteLine($"Z = {z}");
        Console.WriteLine("-------------------------");
        
        double sin = Math.Sin(x);
        double cos = Math.Cos(x);
        double y = sin * sin + cos * cos;
        
        // Prints out the answer
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Y = {y}");
        Console.ResetColor();
        Console.WriteLine("-------------------------");
    }
}