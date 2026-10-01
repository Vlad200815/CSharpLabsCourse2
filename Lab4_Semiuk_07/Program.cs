using System.Text;

Console.WriteLine("Lab4");
Console.WriteLine("Student: Semeniuk Vlad");
Console.WriteLine("Group: IPZ-21");
Console.WriteLine("Variant: 7");
Console.WriteLine();


string divider = "-------------------------------------";

Console.Write("Enter your text: ");
string text = Console.ReadLine() ?? "";


if (string.IsNullOrWhiteSpace(text))
{
    Console.WriteLine("Your text is invalid.");
    return;
}


int letterCount = 0;
int digitCount = 0;
int whiteSpaceCount = 0;
int punctuationCount = 0;
int upperCount = 0;
int lowerCount = 0;


foreach (char symbol in text)
{
    if (char.IsLetter(symbol))
    {
        letterCount++;
    }
    if (char.IsDigit(symbol))
    {
        digitCount++;
    }
    if (char.IsWhiteSpace(symbol))
    {
        whiteSpaceCount++;
    }
    if (char.IsPunctuation(symbol))
    {
        punctuationCount++;
    }
    if (char.IsUpper(symbol))
    {
        upperCount++;
    }
    if (char.IsLower(symbol))
    {
        lowerCount++;
    }
}

Console.WriteLine(divider);
Console.WriteLine($"User's text: {text}");
Console.WriteLine($"Length: {text.Length}");
Console.WriteLine($"The first symbol: '{text[0]}', index: 0");
Console.WriteLine(
    $"The last symbol: '{text[^1]}', " +
    $"index {text.Length - 1}");

Console.WriteLine($"Letter count: {letterCount}");
Console.WriteLine($"Digits count: {digitCount}");
Console.WriteLine($"White space count: {whiteSpaceCount}");
Console.WriteLine($"Punctuation count: {punctuationCount}");
Console.WriteLine($"Upper count: {upperCount}");
Console.WriteLine($"Lower count: {lowerCount}");
Console.WriteLine(divider);



// White spaces don't create empty words.
string[] words = text.Split(
    ' ',
    StringSplitOptions.RemoveEmptyEntries);
Console.WriteLine($"Words count: {words.Length}");

for (int i = 0; i < words.Length; i++)
{
    Console.WriteLine($"{i + 1}) {words[i]} — {words[i].Length}");
}

Console.WriteLine(divider);

// Example of an individual exercise.
Console.WriteLine($"Starting text: {text}");

StringBuilder result = new StringBuilder();


for (int i = 0; i < text.Length; i++)
{
    if (i % 2 == 0)
    {
        result.Append(text[i]);
    }
}



string changedText = result.ToString();
Console.WriteLine($"Result: {changedText}");
Console.WriteLine(divider);

