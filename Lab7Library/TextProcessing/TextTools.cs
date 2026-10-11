using System.Text;

namespace Lab7Library.TextProcessing;

public static class
    TextTools
{
    public static string ReplaceDigitsWithAsterisk(string text)
    {  
        ArgumentNullException.ThrowIfNull(text);
        
        var sb = new StringBuilder(text.Length);
        
        foreach (char symbol in text)
        {
            sb.Append(char.IsDigit(symbol) ? '*' : symbol);
        }

        return sb.ToString();

    }
}

