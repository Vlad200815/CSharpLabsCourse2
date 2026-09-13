
using System.Dynamic;
using CSharpLabsCourse2;

class Program
{
    
    static void Main()
    {   
        // Variant 7 setup
        double a = 2.4;
        double b = -0.8;
        
        double start = -3.5;
        double step = 0.5;
        double count = 19;
        
        int p = -1;
        int q = 2;

        string divider = "-------------------";
        
        Console.WriteLine("Vlad Semeniuk - Variant 7");
        Console.WriteLine($"A: {a}, B: {b}, Start: {start}, Step: {step}, Count: {count}");
        
        bool isContinue = true;
         
        // Executes do block then iterates
        do
        {   
            // Ask for a user's x
            Console.Write("Enter x: ");

            double inputX;

            // Asks until a user enters a valid x
            while (!double.TryParse(Console.ReadLine(), out  inputX))
            {
                Console.Write($"Error, enter a valid x: ");
    
            }
            
            Console.WriteLine(divider);
            
            // Choose options
            Console.WriteLine("1 — Calculate a single value\n" + "2 — Build Table\n" + "0 — Exit the program");
            Console.Write("Choose option: ");
            
            // Parse user's input until a user enters a valid option
            int option;
            while (!int.TryParse(Console.ReadLine(), out option) && (option < 0 || option > 2))
            {
                Console.Write($"Invalid option, enter a valid option: ");
            }
            
            
            // 3 Options
            switch (option)
            {   
                // Calculate Expression
                case 1:
                    CalculateExpression.Calculate(
                        a: a, 
                        b: b, 
                        inputX: inputX, 
                        q: q, 
                        p: p
                    );
                    break;
                
                // Build Table
                case 2: 
                    BuildTable.Build(
                        a: a, 
                        b: b, 
                        inputX: inputX, 
                        start: start, 
                        count: count, 
                        step: step, 
                        q: q, 
                        p: p
                    );
                    break;
                
                // Exit the infinite loop
                case 0:
                    isContinue = false;
                    break;
            }
            
        }
        
        // Infinity loop
        while (isContinue);
        
    }
}











