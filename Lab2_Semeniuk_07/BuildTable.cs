namespace CSharpLabsCourse2;

public class BuildTable
{
    
    public static void Build(
        double a, 
        double b, 
        double inputX, 
        double start, 
        double count, 
        double step, 
        double q, 
        double p
        )
    {
        double maxY = 0;
        double xForMax = 0;

        string headerFormat = "| {0, -4} | {1, 10} | {2, 10} |";
        string dataFormat   = "| {0, -4} | {1, 10:F3} | {2, 10:F3} |";
        string divider       = "-----------------------------------";

        Console.WriteLine(divider);
        Console.WriteLine(headerFormat, "No", "x", "y");
        Console.WriteLine(divider);

        for (int i = 0; i < count; i++)
        {
            // Calculate the argument based on the iteration number.
            double currentX = start + i * step;
            double currentY;
    
            // At each iteration, select one branch of the function.
            if (currentX < p)
            {
                currentY = a * Math.Pow(inputX, 2) + b;
            }
            else if (currentX < q)
            {
                currentY = Math.Sqrt(Math.Abs(inputX) + a);
            }
            else
            {
                currentY = (inputX + b) / (1 + Math.Abs(inputX));
            }
    
            Console.WriteLine(dataFormat, i, currentX, currentY);
    
            // The first value becomes the initial maximum.
            if (i == 0 || currentY > maxY)
            {
                maxY = currentY;
                xForMax = currentX;
            }
        }
        Console.WriteLine(divider);
        Console.WriteLine($"Maximum y = {maxY:F3} when x = {xForMax:F3}");
    }

    
}