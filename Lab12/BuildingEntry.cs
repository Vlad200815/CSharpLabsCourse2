namespace Lab12;


public class BuildingEntry
{
    public string Code { get; }
    public string Address { get; }
    public int FloorCount { get; }

    public BuildingEntry(string code, string address, int floorCount)
    {
        Code = code;
        Address = address;
        FloorCount = floorCount;
    }



    public string GetInfo()
    {
        return $"Code: {this.Code}, address — {this.Address}, floorCount: {this.FloorCount}";
    }
    
}


