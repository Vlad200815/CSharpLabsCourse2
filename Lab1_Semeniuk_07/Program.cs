
using Lab1_Semeniuk_07;


class Program
{
     private static void ExecuteExercise1()
    {
        Console.WriteLine("Lab1 Variant 07");
        InfoValidator.StartInfoValidator();
    }
    
    private static void ExecuteExercise2()
    {
        MathFormula.SolveExpression();
    }
    
     private static void ExecuteExercise3()
    {   
        Console.WriteLine("Guess a random number game!");
        Console.WriteLine("Try to guess a random number between 1 and 100!");
        GuessGame.StartGame();
        Console.WriteLine("The game is over!");
        
    }
    
    /// <summary>
    /// Entry point of the program.
    /// </summary>
    static void Main()
    {  
        // Call the exercises
        ExecuteExercise1();
        ExecuteExercise2();
        ExecuteExercise3();

    }
}








