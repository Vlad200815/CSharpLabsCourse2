using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using  NBUExchangeApp.Models;


namespace NBUExchangeApp.Services;

public class ExchangeApiService
{
    private static readonly HttpClient Client = new HttpClient();
    
    const string ACHCodeKey = "r030";
    const string TextKey = "txt";
    const string RateKey = "rate";
    const string CurrencyKey = "cc";
    const string ExchangedateKey = "exchangedate";
    const string SpecialKey = "special";

    
    
    public static async Task<List<ExchangeReading>> LoadExchangeDataAsync()
    {
        const string url = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchangenew?json";
        
            
        // Надсилаємо HTTP GET і отримуємо JSON як текст.
        string json = await Client.GetStringAsync(url);
        
        
        // Перетворюємо текст на дерево JSON-елементів.
        using JsonDocument document = JsonDocument.Parse(json);
         
        var readings = new List<ExchangeReading>();


        foreach (var item in document.RootElement.EnumerateArray())
        {
            readings.Add(new ExchangeReading
            {
                ACHCode = item.GetProperty(ACHCodeKey).GetInt32(),
                Text = item.GetProperty(TextKey).GetString() ?? "Unknown",
                Rate = item.GetProperty(RateKey).GetDouble(),
                Currency = item.GetProperty(CurrencyKey).GetString() ?? "Unknown",
                ExchangeDate = item.GetProperty(ExchangedateKey).GetString() ?? "Unknown",
                Special = item.GetProperty(SpecialKey).GetString() ?? "Unknown"
            } );
        }


        return readings;
    }
    
    
}