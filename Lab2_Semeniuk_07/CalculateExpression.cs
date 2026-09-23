namespace CSharpLabsCourse2;

public static class CalculateExpression
{
    public static void Calculate(
        double a, 
        double b, 
        double inputX, 
        double q, 
        double p
        )
    {
        
        double singleY;
        
        // Evaluates a piecewise function Y(x) across three intervals defined by thresholds 'p' and 'q':
        // 1) x < p     : Quadratic branch -> a * x^2 + b
        // 2) p <= x < q: Square root branch -> sqrt(|x| + a)
        // 3) x >= q    : Rational branch    -> (x + b) / (1 + |x|)
        
        if (inputX < p)
        {   
            singleY = a * Math.Pow(inputX, 2) + b;
        }
        else if (inputX < q)
        {
            singleY = Math.Sqrt(Math.Abs(inputX) + a);
        }
        else
        {   
            singleY = (inputX + b) / (1 + Math.Abs(inputX));
        }

        Console.WriteLine($"x = {inputX:F3}; y = {singleY:F3}");
        
        
        
    }
}