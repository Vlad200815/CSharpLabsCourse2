using System.Security.AccessControl;

class Program
{
    static void Main()
    {
        var variant = 7;
        var n = 19;
        var minValue = -60;
        var maxValue = 60;
        var type = "B";
        var p = 5;

        int[] testNumbers = { -10, -5, 0, 5, 10 };
        double[] empty = { };


        PrintDivider();
        PrintStudentInfo("Vlad Semeniuk", "IPZ-21", variant);
        PrintDivider();
        var randomNumbers = CreateRandomArray(n, minValue, maxValue, variant);
        PrintArray("Random List", randomNumbers);
        PrintDivider();
        Console.WriteLine($"Sum: {Sum(randomNumbers)}");
        PrintDivider();
        PrintDivider();
        Console.WriteLine($"Avrage: {Average(randomNumbers)}");
        PrintDivider();
        Console.WriteLine($"Min: {FindMinimum(randomNumbers)}");
        Console.WriteLine($"Max {FindMaximum(randomNumbers)}");
        PrintDivider();
        Console.WriteLine($"Sum Divisible By For Random Numbers: {p} = {SumDivisibleBy(randomNumbers, p)}");
        Console.WriteLine($"Sum Divisible By For Test Numbers: {p} = {SumDivisibleBy(testNumbers, p)}");
        PrintDivider();
        Console.WriteLine($"{CountWords("Hello World \n   kdfjkdsa \t dkfjd")}");
        PrintDivider();
        
        
        Console.WriteLine($"Average Many: {AverageMany(9)}");
        Console.WriteLine($"Average Many: {AverageMany(9, 8, 6)}");
        Console.WriteLine($"Average Many: {AverageMany(empty)}");

        PrintDivider();


    }

    static void PrintDivider()
    {
        const string divider = "--------------------------------------------------------------------------------------";
        Console.WriteLine(divider);
    }


    static void PrintStudentInfo(string fullName, string group, int variant)
    {
        Console.WriteLine($"Full Name: {fullName}");
        Console.WriteLine($"Group: {group}");
        Console.WriteLine($"Variant: {variant}");
    }


    static int[] CreateRandomArray(
        int length,
        int minValue,
        int maxValue,
        int seed)
    {
        var result = new int[length];
        var random = new Random(seed);

        for (int i = 0; i < length; i++)
        {
            result[i] = random.Next(minValue, maxValue + 1);
        }

        return result;
    }

    static void PrintArray(string title, int[] numbers)
    {
        Console.WriteLine($"{title}: [{string.Join(", ", numbers)}]");
    }

    static int Sum(int[] numbers)
    {
        return numbers.Sum();
    }


    static double Average(int[] numbers)
    {   
        if (numbers.Length == 0) return 0;
        
        var sum = Sum(numbers);
        return (double)sum / numbers.Length;

    }


    static int FindMinimum(int[] numbers)
    {
        var minNum = numbers[0];

        for (var i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] < minNum)
            {
                minNum = numbers[i];
            }
        }

        return minNum;
    }


    static int FindMaximum(int[] numbers)
    {
        var maxNum = numbers[0];

        for (var i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > maxNum)
            {
                maxNum = numbers[i];
            }
        }

        return maxNum;
    }

    static int SumDivisibleBy(int[] numbers, int p)
    {
        var sum = 0;

        foreach (var number in numbers)
        {
            if (number % p == 0)
            {
                sum += number;
            }
        }

        return sum;
    }
    

    static int CountWords(string text)
    {
        var words = RemoveExtraSpaces(text).Split(" ");
        Console.WriteLine($"Words: {string.Join(",", words)}");
        var counter = 0;
        
        foreach (var word in words) counter++;
        
        return counter;
    }


    static string RemoveExtraSpaces(string text)
    { 
        return string.Join(" ", text.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries));
    }

    static double AverageMany(params double[] values)
    {
        if (values.Length == 0) return 0;
         
        double sum = 0;

        foreach (var num in values)
        {
            sum = sum + num;
        }
        
        return sum / values.Length;

    }
}