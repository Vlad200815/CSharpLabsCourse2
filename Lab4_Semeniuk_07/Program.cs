using System.Text;

Console.WriteLine("Lab No4");
Console.WriteLine("Student: Semeniuk Vlad");
Console.WriteLine("Група: IPZ-21");
Console.WriteLine("Варіант: 7");
Console.WriteLine();


string divider = "-----------------------------";

Console.Write("Enter your text: ");
string? text = Console.ReadLine();

// Check user's text for null and empty strings
if (string.IsNullOrWhiteSpace(text))
{
    Console.WriteLine("Please enter a valid text");
    return;
}

Console.WriteLine(divider);
    // Prints out user's text with exta info
    Console.WriteLine($"Your text is: {text}, length of your text is: {text.Length}");
    Console.WriteLine(
        $"First symbol is: {text[0]} index is: {text.IndexOf(text[0])}." + 
        $" Last symbol is: {text[^1]}, index is: {text.LastIndexOf(text[^1])}."
        );
    Console.WriteLine(divider);

    
    // Set default variables
    int letters = 0;
    int digits = 0;
    int whiteSpaces = 0;
    int punctuations = 0;
    int upperLetters = 0;
    int lowerLetters = 0;

    foreach (var t in text)
    {  
        // Letters
        if (char.IsLetter(t))
        {
            letters++;
            
            // Check for Lower and Upper
            if (char.IsLower(t))
            {
                lowerLetters++;
            }
            else
            {
                upperLetters++;
            }
            
        // Digits    
        }else if (char.IsDigit(t))
        {
            digits++;
            
        // Punctuation Signs    
        }else if (char.IsPunctuation(t)){
            punctuations++;
           
        // White Spaces    
        }else if (char.IsWhiteSpace(t))
        {
            whiteSpaces++;
        }
    }
    
    // Counts user's text's chars 
    Console.WriteLine(divider);
    Console.WriteLine($"Letters: {letters}");
    Console.WriteLine($"Digits: {digits}");
    Console.WriteLine($"White spaces: {whiteSpaces}");
    Console.WriteLine($"Punctuations: {punctuations}");
    Console.WriteLine($"Lower letters: {lowerLetters}");
    Console.WriteLine($"Upper letters: {upperLetters}");
    Console.WriteLine(divider);
    
    // Turn string into list of strings and prints its info
    string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    for (int i = 0;
    i < words.Length; i++)
    {
        Console.WriteLine($"{words[i]}.\tOrdinal number is: {i + 1}.\tLength is: {words[i].Length}");
    } 
    Console.WriteLine(divider);


    // The second exercise, variant 7
    StringBuilder result = new StringBuilder();

    for (int i = 0; i < text.Length; i++)
    {
        if (i % 2 == 0)
        {
            result.Append(text[i]);
        }
    }

    string changedText = result.ToString();
    Console.WriteLine();
    Console.WriteLine($"Result: {changedText}");
    Console.WriteLine($"Length: {changedText.Length}");
    Console.WriteLine(divider);




