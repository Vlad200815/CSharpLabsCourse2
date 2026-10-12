namespace Lab8Models;

public class Book : Publication
{
    public int ChapterCount { get; }

    public Book(int chapterCount, string title, int pageCount) 
        : base(title, pageCount)
    {
        ChapterCount = chapterCount;
    }
    

    public double CalculateAveragePagesPerChapter()
    {  
        return (double)this.PageCount / this.ChapterCount;
    }

    public string GetInfo()
    {
        return $"{base.GetCommonDescription()}, " +
               $"chapter count: {ChapterCount}";
    }
}