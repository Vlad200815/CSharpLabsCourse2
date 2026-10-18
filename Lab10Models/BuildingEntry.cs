namespace Lab10Models;


public class BuildingEntry : IEntry
{
    public string Code { get; }
    public string Address { get; }
    public string Purpose { get; }
    public int FloorCount { get; }

    public BuildingEntry(string code, string address, string purpose, int floorCount)
    {
        Code = code;
        Address = address;
        Purpose = purpose;
        FloorCount = floorCount;
    }



    public string GetInfo()
    {
        return $"Code: {this.Code}, address — {this.Address}, purpose: {this.Purpose}, floorCount: {this.FloorCount}";
    }
    
}

    
