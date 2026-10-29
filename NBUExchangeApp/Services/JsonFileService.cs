namespace NBUExchangeApp.Services;

using System.IO;
using System.Text.Json;
using System.Threading.Tasks;


public static class JsonFileService
{
    private static readonly JsonSerializerOptions Options = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true
    };
    
    
    public static async Task SaveAsync<T>(string filePath, T data)
    {
        string json = JsonSerializer.Serialize(data, Options);
        await File.WriteAllTextAsync(filePath, json);
    }
    
    
    public static async Task<T> LoadAsync<T>(string filePath)
    {
        string json = await File.ReadAllTextAsync(filePath);
        T? data = JsonSerializer.Deserialize<T>(json, Options);
        
        if (data is null)
        {
            throw new JsonException(
                "JSON не містить очікуваного об’єкта.");
        }
        
        return data;
    }
}