namespace Lab8Models;

public class Fiction : Book
{
    public string Genre { get; }

    public Fiction(string genre, int chapterCount, string title, int pageCount) 
        : base(title: title, pageCount: pageCount, chapterCount: chapterCount)
    {
        Genre = genre;
    }

    public bool IsSuitableForChildren()
    {
        string normalized = Genre.ToLowerInvariant();
        return !(normalized.Contains("horror") || normalized.Contains("thriller") || normalized.Contains("crime"));
    }

    public string GetDetailedInfo()
    {
        return base.GetInfo() + $", genre: {Genre}";
    }
    
}