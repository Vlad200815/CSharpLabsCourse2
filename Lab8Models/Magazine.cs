namespace Lab8Models;

public sealed class Magazine : Publication
{
    public int IssueNumber { get; }

    public Magazine(int issueNumber, string title, int pageCount) 
        : base(title, pageCount)
    {
        IssueNumber = issueNumber;
    }


    public string CreateIssueLabel()
    {
        return $"{this.Title}-#{this.IssueNumber}";
    }
    
    public string GetInfo()
    {
        return $"{base.GetCommonDescription()}, " +
               $"issueNumber: {IssueNumber}";
    }
}