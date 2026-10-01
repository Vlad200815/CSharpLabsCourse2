
using System;
using System.Net.Mime;
using System.Text;

namespace AvaloniaApplication1;



public class TextAnalysisResult
{
    public int Length { get; init; }
    public char FirstChar { get; init; }
    public char LastChar { get; init; }
    public int Letters { get; init; }
    public int Digits { get; init; }
    public int WhiteSpaces { get; init; }
    public int PunctuationCount { get; init; }
    public int UpperCount { get; init; }
    public int LowerCount { get; init; }
    public string[] Words { get; init; } = Array.Empty<string>();
    public string FilteredEvenChars { get; init; } =  string.Empty;
    
}

public class TextAnalyzer
{
    private const string Divider = "-------------------------------------\n";

    public TextAnalysisResult Analyse(string inputText)
    {
        int letters = 0, digits = 0, whiteSpaces = 0, punctuations = 0, upperCase = 0, lowerCase = 0;
        
        foreach (char symbol in inputText)
        {
            if (char.IsLetter(symbol)) letters++;
            if (char.IsDigit(symbol)) digits++;
            if (char.IsWhiteSpace(symbol)) whiteSpaces++;
            if (char.IsPunctuation(symbol)) punctuations++;
            if (char.IsUpper(symbol)) upperCase++;
            if (char.IsLower(symbol)) lowerCase++;
        }
        
        
        var evenChars = new StringBuilder(inputText.Length / 2 + 1);
        for (var i = 0; i < inputText.Length; i += 2) evenChars.Append(inputText[i]);

        return new TextAnalysisResult()
        {
            Length = inputText.Length,
            FirstChar = inputText[0],
            LastChar = inputText[^1],
            Letters = letters,
            Digits = digits,
            WhiteSpaces = whiteSpaces,
            PunctuationCount = punctuations,
            UpperCount = upperCase,
            LowerCount = lowerCase,
            Words = inputText.Split(' ', StringSplitOptions.RemoveEmptyEntries),
            FilteredEvenChars = evenChars.ToString(),
        };
    }


    public string FormatReport(string rawInput, TextAnalysisResult stats)
    {
        var sb = new StringBuilder();
        
        sb.AppendLine("Lab4");
        sb.AppendLine("Student: Semeniuk Vlad");
        sb.AppendLine("Group: IPZ-21");
        sb.AppendLine("Variant: 7");
        sb.AppendLine(Divider);
        sb.AppendLine($"User's text: {rawInput}");
        sb.AppendLine($"Length: {rawInput.Length}");
        sb.AppendLine($"The first symbol: '{rawInput[0]}', index: 0");
        sb.AppendLine($"The last symbol: '{rawInput[^1]}', " +
                      $"index {rawInput.Length - 1}");
        sb.AppendLine($"Letter count: {stats.Letters}");
        sb.AppendLine($"Digits count: {stats.Digits}");
        sb.AppendLine($"White space count: {stats.WhiteSpaces}");
        sb.AppendLine($"Punctuation count: {stats.PunctuationCount}");
        sb.AppendLine($"Upper count: {stats.UpperCount}");
        sb.AppendLine($"Lower count: {stats.LowerCount}\n");
        
        
        sb.AppendLine(Divider);
        for (var i = 0; i < stats.Words.Length; i++)
        {
            sb.AppendLine($"{i + 1}) {stats.Words[i]} — {stats.Words[i].Length}");
        }
        sb.AppendLine(Divider);
        
        
        sb.AppendLine($"Starting text: {rawInput}");
        sb.AppendLine($"Result: (even index) {stats.FilteredEvenChars}");
        sb.AppendLine(Divider);
        
        return sb.ToString();
    }
}