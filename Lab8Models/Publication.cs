namespace Lab8Models;

public class Publication
{
    public string Title { get; }
    public int PageCount { get; }
    
    public Publication(string title, int pageCount)
    {
        Title = title;
        PageCount = pageCount;
    }

    public string GetBaseInfo()
    {
        return $"Base Info: {GetCommonDescription()}";
    }

    protected string GetCommonDescription()
    {
        return $"title: {Title}, pageCount: {PageCount}";
    }
}