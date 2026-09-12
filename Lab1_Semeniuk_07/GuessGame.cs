namespace Lab1_Semeniuk_07;
using System;


enum GameStatus {Initial, TooBig, TooSmall, Guessed}


public static class GuessGame
{   
    private static Random? _random;
    private static int _guessNumber;
    private static GameStatus _gameStatus;
    private static int _trys;

    /// <summary>
    /// Generates a random number between (min and max values)
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    static void GenerateNewGuessedNumber(int min, int max)
    {
        _random = new Random();
        _guessNumber = _random.Next(min, max + 1);
    }
    
    /// <summary>
    /// Init constructor with default values
    /// </summary>
    static GuessGame()
    {
        _gameStatus = GameStatus.Initial;
        _trys = 0;
        GenerateNewGuessedNumber(1, 100);
    }
    
    
    /// <summary>
    /// Print Status-Bar for the game  
    /// </summary>
    /// <param name="userNumber"></param>
    /// <param name="status"></param>
    /// <param name="trys"></param>
    private static void PrintGameStatusBar(int userNumber, GameStatus status, int trys)
    {
        Console.WriteLine(new string('-', 66));
        
        // Red color for wrong answers
        Console.ForegroundColor = ConsoleColor.Red;
        // Green for the correctly guessed number
        if (status == GameStatus.Guessed) Console.ForegroundColor = ConsoleColor.Green;
        
        Console.WriteLine($"\tYour number: {userNumber} | Game Status: {status} | Trys: {trys,-10}\t");
        Console.ResetColor();
        Console.WriteLine(new string('-', 66));
    }

    /// <summary>
    /// Start the Game with infinite loop until a user finds the guessed number
    /// </summary>
    public static void StartGame()
    {
        while (true)
        {   
            Console.Write($"Enter a number: ");
            
            // Check if a user entered a valid value (must be only int)
            if (int.TryParse(Console.ReadLine(), out int userNumber))
            {
                _trys++;
                if (_guessNumber == userNumber)
                {
                    _gameStatus = GameStatus.Guessed;
                    PrintGameStatusBar(userNumber, _gameStatus, _trys);
                    // Exit the loop if a user guesses the number
                    break;
                }
                
                if (_guessNumber > userNumber)
                {
                    _gameStatus = GameStatus.TooSmall;
                    PrintGameStatusBar(userNumber, _gameStatus, _trys);
                }else if (_guessNumber < userNumber)
                {
                    _gameStatus = GameStatus.TooBig;
                    PrintGameStatusBar(userNumber, _gameStatus, _trys);
                }
            }
            else
            {
                Console.WriteLine("You entered invalid value!");
            }
        }
        
    }
    
}